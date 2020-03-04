using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Scaffold.Domain.Models.Product;

namespace Scaffold.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AmazonDynamoDBClient dbClient;

        public ProductRepository(AmazonDynamoDBClient dbClient)
        {
            this.dbClient = dbClient;
        }

        public async Task AddProduct(Product product)
        {
            var table = Table.LoadTable(dbClient, "products_sku");
            Document document = DocumentFromProduct(product);

            await table.PutItemAsync(document);
        }

        private static Document DocumentFromProduct(Product product)
        {
            var document = new Document();

            document["sku"] = product.sku;
            document["id"] = product.id;
            document["name"] = product.name;
            document["shortDescription"] = product.shortDescription;
            document["longDescription"] = product.longDescription;
            document["imageUrl"] = product.imageUrl;
            document["price.amount"] = product.price.amount;
            document["price.currencyCode"] = product.price.currencyCode;
            document["price.scale"] = product.price.scale;

            return document;
        }

        public bool AlreadyExists(string sku)
        {
            var table = Table.LoadTable(dbClient, "products_sku");

            return table.Query(new QueryFilter("sku", QueryOperator.Equal, new List<AttributeValue>()
            {
                new AttributeValue()
                {
                    S = sku
                }
            })).Count > 0;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var table = Table.LoadTable(dbClient, "products_sku");

            var scanFilter = new ScanFilter();

            var scanOperation = new ScanOperationConfig()
            {
                Filter = scanFilter
            };

            var result = table.Scan(scanOperation);

            var products = new List<Product>();

            while (!result.IsDone)
            {
                var querySet = await result.GetNextSetAsync();

                foreach (var document in querySet)
                {
                    Product product = ProductFromDocument(document);
                    products.Add(product);
                }
            }

            return products;
        }

        public async Task<Product> GetProduct(string sku)
        {
            var table = Table.LoadTable(dbClient, "products_sku");

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

                Product product = ProductFromDocument(document);

                return product;
            }
        }

        private static Product ProductFromDocument(Document document)
        {
            var product = new Product();

            product.sku = document["sku"].AsString();
            product.id = document["id"].AsGuid();
            product.name = document["name"].AsString();
            product.shortDescription = document["shortDescription"].AsString();
            product.longDescription = document["longDescription"].AsString();
            product.imageUrl = document["imageUrl"].AsString();
            product.price = new ProductPrice();
            product.price.amount = document["price.amount"].AsLong();
            product.price.currencyCode = document["price.currencyCode"].AsString();
            product.price.scale = document["price.scale"].AsLong();

            return product;
        }
    }
}