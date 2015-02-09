using CqrsDomain.Mongo.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CqrsDal.Tests
{
    [TestClass]
    public class MongoRepositoryTest
    {
        [TestMethod]
        public void MongoRepository_InsertProduct_ShouldSucceed()
        {
            // Arrange
            var repository = new MongoRepository();
            var product = new QueryProduct
                              {
                                  _id =  4,
                                  ProductId = 4,
                                  QueryCategory = new QueryCategory { CategoryId = 2, CategoryName = "testing" },
                                  Name = "Chef Anton's Cajun Seasoning",
                                  QuerySupplier = new QuerySupplier { Id = 2, Name = "New Orleans Cajun Delights", Address = "", City = "", Country = "", HomePage = "", Phone = "", PostalCode = "" },
                                  QuantityPerUnit = "multiple",
                                  UnitPrice = 20.00m,
                                  UnitsInStock = 100
                              };
            
            // Act
            repository.InsertProduct(product);
            var result = repository.FindProduct(product.ProductId);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MongoRepository_FindProduct_ShouldReturnProduct()
        {
            // Arrange
            var repository = new MongoRepository();
            var productId = 4;
            
            // Act
            var product = repository.FindProduct(productId);

            // Assert
            Assert.IsTrue(product.Name == "Chef Anton's Cajun Seasoning");
        }


        [TestMethod]
        public void MongoRepository_UpdateProduct_ShouldUpdateUnitPrice()
        {
            // Arrange
            var expected = 20.00m;
            var unitPrice = 20.00m;
            var repository = new MongoRepository();
            var productId = 4;
            var product = repository.FindProduct(productId);
            product.UnitPrice = unitPrice;
            repository.UpdateProduct(product);

            // Act
            var result = repository.FindProduct(productId).UnitPrice;

            // Assert
            Assert.AreEqual(expected, result);

        }
    }
}
