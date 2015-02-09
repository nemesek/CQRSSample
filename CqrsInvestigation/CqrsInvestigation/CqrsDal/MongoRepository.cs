using CqrsDomain.Contracts;
using CqrsDomain.Mongo.Model;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;

namespace CqrsDal
{
    public class MongoRepository : IMongoRepository, IQuery
    {
        private readonly string _connectionString;
        private readonly MongoClient _client;
        private readonly MongoDatabase _database;
        private readonly MongoServer _server;
        private readonly MongoCollection<QueryProduct> _collection;

        public MongoRepository()
        {
            _connectionString = "mongodb://localhost";
            _client = new MongoClient(_connectionString);
            _server = _client.GetServer();
            _database = _server.GetDatabase("cqrs");
            _collection = _database.GetCollection<QueryProduct>("products");
        }

        public void InsertProduct(QueryProduct queryProduct)
        {
            if (queryProduct == null) return;
            var query = Query<QueryProduct>.EQ(p => p.ProductId, queryProduct.ProductId);
            var tempProduct = _collection.FindOne(query);
            if (tempProduct == null)
            {
                _collection.Insert(queryProduct);

            }
        }

        public QueryProduct FindProduct(int productId)
        {
            QueryProduct queryProduct = null; 

            if (productId > 0)
            {
                var query = Query<QueryProduct>.EQ(p => p.ProductId, productId);
                queryProduct = _collection.FindOne(query);
            }

            return queryProduct;
        }

        public IEnumerable<QueryProduct> FindProducts()
        {
            var products = _collection.FindAll().SetLimit(10);
            return products;
        }

        public void UpdateProduct(QueryProduct product)
        {
            if (product == null) return;

            var query = Query<QueryProduct>.EQ(p => p.ProductId, product.ProductId);
            var queryProduct = _collection.FindOne(query);
            
            if (queryProduct == null) this.InsertProduct(product);        // Todo: Figure out how I want to handle
            
            _collection.Save(product);
            
        }
    }
}
