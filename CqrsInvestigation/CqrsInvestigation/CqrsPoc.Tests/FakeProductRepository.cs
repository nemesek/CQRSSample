using System.Collections.Generic;
using CqrsDomain.Contracts;
using CqrsDomain.Mongo.Model;
using CqrsDomain.Northwind.Model;

namespace CqrsPoc.Tests
{
    public class FakeProductRepository : IProductsRepository, ICommand
    {
        private readonly List<Product> _products = new List<Product>();
        public bool SaveChangesHasBeenCalled { get; set; }
        public bool ResetProductTableHasBeenCalled { get; set; }

        public void Add(ref Product item)
        {
            _products.Add(item);
        }

        public void Delete(int key)
        {
            var product = _products.Find(p => p.ProductId == key);
            _products.Remove(product);
        }

        public Product FindByKey(int key)
        {
            //throw new System.NotImplementedException();
            var product = _products.Find(p => p.ProductId == key);
            return product;
        }

        public IEnumerable<Product> FindAll()
        {
            return _products;
        }

        public IEnumerable<Product> Find(string filterExpression)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> FindRange(string filterExpression, string sortingExpression, int startIndex, int count)
        {
            throw new System.NotImplementedException();
        }

        public int GetCount(string filterExpression)
        {
            return _products.Count;
        }

        public void SaveChanges()
        {
            SaveChangesHasBeenCalled = true;
        }

        public void SaveChanges(int productId, string categoryName)
        {
            SaveChangesHasBeenCalled = true;
        }

        public void SaveProductCategoryChanges(Product product)
        {
            SaveChangesHasBeenCalled = true;
        }

        public void SaveChanges(Product contextObject)
        {
            SaveChangesHasBeenCalled = true;
        }


        public void ResetProductTable()
        {
            ResetProductTableHasBeenCalled = true;
        }

        public void UpdateProduct(QueryProduct queryProduct)
        {
        }
    }
}