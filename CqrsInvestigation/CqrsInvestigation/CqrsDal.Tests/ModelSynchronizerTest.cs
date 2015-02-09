using CqrsDal.Contracts;
using CqrsDomain.Northwind.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CqrsDal.Tests
{
    [TestClass]
    public class ModelSynchronizerTest
    {
        [TestMethod]
        public void ModelSynchronizer_UpdateQueryProduct_ShouldUpdateMongoDb()
        {
            // Arrange
            var commandRepository = new ProductsRepository();
            var productId = 4;
            var expected = 22.00m;
            var commandProduct = commandRepository.FindByKey(productId);
            var queryRepository = new MongoRepository();
            IPushProductMessages messageDispatcher = new FakePushProductMessages();
            commandProduct.UnitPrice = 22.00m;
            var modelSynchronizer = new ModelSynchronizer(queryRepository, messageDispatcher);

            // Act
            modelSynchronizer.UpdateQueryProduct(commandProduct);
            var result = queryRepository.FindProduct(productId).UnitPrice;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ModelSynchronizer_MapProductToQueryProduct_ShouldReturnQueryProduct()
        {
            // Arrange
            IPushProductMessages messageDispatcher = new FakePushProductMessages();
            var modelSynchronizer = new ModelSynchronizer(null, messageDispatcher);
            var commandProduct = new Product
            {
                ProductId = 1,
                Category = new Category { CategoryId = 1, CategoryName = "TestCategory" },
                CategoryId = 1,
                Name = "Product1",
                QuantityPerUnit = "multiple",
                Supplier = new Supplier { Name = "Joe Supplier", Id = 5 },
                SupplierId = 5,
                UnitPrice = 20.00m,
                UnitsInStock = 5
            };

            var expectedCategoryName = "TestCategory";
            var expectedSupplierId = 5;

            // Act
            var result = modelSynchronizer.MapProductToQueryProduct(commandProduct);

            // Assert 
            Assert.AreEqual(expectedCategoryName, result.QueryCategory.CategoryName);
            Assert.AreEqual(expectedSupplierId, result.QuerySupplier.Id);
        }
    }
}
