using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Scaffold.Domain.Models.Cart;

namespace Scaffold.Infra.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AmazonDynamoDBClient dbClient;

        public CartRepository(AmazonDynamoDBClient dbClient)
        {
            this.dbClient = dbClient;
        }

        public async Task AddCart(Cart cart)
        {
            var table = Table.LoadTable(dbClient, "cart_sku");
            Document document = DocumentFromCart(cart);

            await table.PutItemAsync(document);
        }

        private static Document DocumentFromCart(Cart cart)
        {
            var document = new Document();

            //document["sku"] = cart.sku;
            //document["id"] = cart.id;
            //document["name"] = cart.name;
            //document["shortDescription"] = cart.shortDescription;
            //document["longDescription"] = cart.longDescription;
            //document["imageUrl"] = cart.imageUrl;
            //document["price.amount"] = cart.price.amount;
            //document["price.currencyCode"] = cart.price.currencyCode;
            //document["price.scale"] = cart.price.scale;

            return document;
        }

        public bool AlreadyExists(string sku)
        {
            var table = Table.LoadTable(dbClient, "carts_sku");

            return table.Query(new QueryFilter("sku", QueryOperator.Equal, new List<AttributeValue>()
            {
                new AttributeValue()
                {
                    S = sku
                }
            })).Count > 0;
        }

        public async Task<IEnumerable<Cart>> GetAllCarts()
        {
            var table = Table.LoadTable(dbClient, "carts_sku");

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

        public async Task<Cart> GetCart(string sku)
        {
            var table = Table.LoadTable(dbClient, "carts_sku");

            var filter = new QueryFilter();
            filter.AddCondition("sku", QueryOperator.Equal, sku);

            var queryConfig = new QueryOperationConfig
            {
                Filter = filter,
                Limit = 1
            };

            var result = table.Query(queryConfig);

            if (result.IsDone)
            {
                throw new ArgumentException("sku");
            }
            else
            {
                var querySet = await result.GetNextSetAsync();

                var document = querySet.First();

                Cart cart = CartFromDocument(document);

                return cart;
            }
        }

        private static Cart CartFromDocument(Document document)
        {
            var cart = new Cart();

            //product.sku = document["sku"].AsString();
            //product.id = document["id"].AsGuid();
            //product.name = document["name"].AsString();
            //product.shortDescription = document["shortDescription"].AsString();
            //product.longDescription = document["longDescription"].AsString();
            //product.imageUrl = document["imageUrl"].AsString();
            //product.price = new ProductPrice();
            //product.price.amount = document["price.amount"].AsLong();
            //product.price.currencyCode = document["price.currencyCode"].AsString();
            //product.price.scale = document["price.scale"].AsLong();

            return cart;
        }
    }
}