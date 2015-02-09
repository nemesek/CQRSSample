using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using CqrsDomain.Contracts;
using CqrsDomain.Mongo.Model;
using CqrsDomain.Northwind.Model;
using Northwind.Repositories.Entity;

namespace CqrsDal
{
    public class ProductsRepository : IProductsRepository, ICommand
    {
        #region Fields

        private ModelSynchronizer _synchronizer;
        private const string ConnStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True"; //Todo: Fix this
        private readonly NorthwindContext _context;
        #endregion

        public ProductsRepository()
        {
            _context = new NorthwindContext(ConnStr);
            _synchronizer = new ModelSynchronizer();
        }
 
        public Product FindByKey(int key)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == key);
        }

        public IEnumerable<Product> FindAll()
        {
            return _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier);
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void SaveChanges(Product product)
        {
            this.SaveChanges();
            _synchronizer = new ModelSynchronizer();
            _synchronizer.UpdateQueryProduct(product);
        }

        public void SaveProductCategoryChanges(Product product)
        {
            this.SaveChanges();
           var products = this.FindAll().Where(p => p.CategoryId == product.CategoryId);

            foreach (var p in products)
            {
                _synchronizer.UpdateQueryProduct(p);
            }
        }

        public void UpdateProduct(QueryProduct queryProduct)
        {
            var product = this.FindAll().SingleOrDefault(p => p.ProductId == queryProduct.ProductId);
            _synchronizer.ResetProductTable();
            if (!product.Category.CategoryName.Equals(queryProduct.QueryCategory.CategoryName))
            {
                product.Name = queryProduct.Name;
                product.Category.CategoryName = queryProduct.QueryCategory.CategoryName;
                this.SaveProductCategoryChanges(product);
            }

            // if only the product name changed, only update this product
            if (product.Name.Equals(queryProduct.Name)) return;

            product.Name = queryProduct.Name;
            product.Category.CategoryName = queryProduct.QueryCategory.CategoryName;
            this.SaveChanges(product);
        }
    }
}
