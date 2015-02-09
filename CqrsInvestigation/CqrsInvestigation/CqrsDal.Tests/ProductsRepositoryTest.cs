using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Repositories.Entity;

namespace CqrsDal.Tests
{
    [TestClass]
    public class ProductsRepositoryTest
    {
        [TestMethod]
        public void ProductRepository_FindAllShouldReturnAllProducts()
        {
            // Arrange
            var target = new ProductsRepository();

            // Act
            var results = target.FindAll();

            // Assert
            Assert.IsTrue(results.Any());
        }

        [TestMethod]
        public void ProductRepository_FindByKey_ShouldReturnProduct()
        {
            // Arrange
            var productId = 4;
            var expected = "Chef Anton's Cajun Seasoning";
            var target = new ProductsRepository();

            // Act
            var result = target.FindByKey(productId).Name;

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
