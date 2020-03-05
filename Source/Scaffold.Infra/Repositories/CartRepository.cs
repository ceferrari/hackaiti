using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Newtonsoft.Json;
using Scaffold.Domain.Models.CartModel;
using Scaffold.Domain.Models.CartModel.Repositories;

namespace Scaffold.Infra.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AmazonDynamoDBClient dbClient;

        public CartRepository(AmazonDynamoDBClient dbClient)
        {
            this.dbClient = dbClient;
        }

        public bool ExistsById(string id)
        {
            var table = Table.LoadTable(dbClient, "carts_id_cid");

            return table.Query(new QueryFilter("id", QueryOperator.Equal, new List<AttributeValue>()
            {
                new AttributeValue()
                {
                    S = id
                }
            })).Count > 0;
        }

        public bool ExistsByCustomerId(string customerId)
        {
            var table = Table.LoadTable(dbClient, "carts_id_cid");

            return table.Query(new QueryFilter("customerId", QueryOperator.Equal, new List<AttributeValue>()
            {
                new AttributeValue()
                {
                    S = customerId
                }
            })).Count > 0;
        }

        public async Task<Cart> GetById(string id)
        {
            var table = Table.LoadTable(dbClient, "carts_id_cid");

            var filter = new QueryFilter();
            filter.AddCondition("id", QueryOperator.Equal, id);

            var queryConfig = new QueryOperationConfig
            {
                Filter = filter,
                Limit = 1
            };

            var result = table.Query(queryConfig);

            if (result.IsDone)
            {
                throw new ArgumentException("id");
            }
            else
            {
                var querySet = await result.GetNextSetAsync();

                var document = querySet.First();

                Cart cart = CartFromDocument(document);

                return cart;
            }
        }

        public async Task<Cart> GetByCustomerId(string customerId)
        {
            var table = Table.LoadTable(dbClient, "carts_id_cid");

            var filter = new QueryFilter();
            filter.AddCondition("customerId", QueryOperator.Equal, customerId);

            var queryConfig = new QueryOperationConfig
            {
                Filter = filter,
                Limit = 1
            };

            var result = table.Query(queryConfig);

            if (result.IsDone)
            {
                throw new ArgumentException("customerId");
            }
            else
            {
                var querySet = await result.GetNextSetAsync();

                var document = querySet.First();

                Cart cart = CartFromDocument(document);

                return cart;
            }
        }

        public async Task<IEnumerable<Cart>> GetAll()
        {
            var table = Table.LoadTable(dbClient, "carts_id_cid");

            var scanFilter = new ScanFilter();

            var scanOperation = new ScanOperationConfig()
            {
                Filter = scanFilter
            };

            var result = table.Scan(scanOperation);

            var carts = new List<Cart>();

            while (!result.IsDone)
            {
                var querySet = await result.GetNextSetAsync();

                foreach (var document in querySet)
                {
                    Cart cart = CartFromDocument(document);
                    carts.Add(cart);
                }
            }

            return carts;
        }

        public async Task Add(Cart cart)
        {
            var table = Table.LoadTable(dbClient, "carts_id_cid");
            Document document = DocumentFromCart(cart);

            await table.PutItemAsync(document);
        }

        public async Task Delete(string id)
        {
            var table = Table.LoadTable(dbClient, "carts_id_cid");

            var filter = new QueryFilter();
            filter.AddCondition("id", QueryOperator.Equal, id);

            var queryConfig = new QueryOperationConfig
            {
                Filter = filter,
                Limit = 1
            };

            var result = table.Query(queryConfig);

            if (result.IsDone)
            {
                throw new ArgumentException("id");
            }
            else
            {
                var querySet = await result.GetNextSetAsync();

                var document = querySet.First();

                document["status"] = "CANCEL";

                await table.PutItemAsync(document);
            }
        }

        private static Document DocumentFromCart(Cart cart)
        {
            var document = new Document();

            document["id"] = cart.id;
            document["customerId"] = cart.customerId;
            document["status"] = cart.status;
            document["items"] = JsonConvert.SerializeObject(cart.items);

            return document;
        }

        private static Cart CartFromDocument(Document document)
        {
            var cart = new Cart();

            cart.id = document["id"].AsGuid();
            cart.customerId = document["customerId"].AsString();
            cart.status = document["status"].AsString();
            cart.items = JsonConvert.DeserializeObject<List<CartItem>>(document["items"].AsString());

            return cart;
        }
    }
}