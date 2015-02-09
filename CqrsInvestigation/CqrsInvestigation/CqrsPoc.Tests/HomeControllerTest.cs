using CqrsDomain.Mongo.Model;
using CqrsDomain.Northwind.Model;
using CqrsPoc.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CqrsPoc.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void HomeController_UpdateCategoryName_ShouldReturnSuccess()
        {
        //    // Arrange
        //    var repository = new FakeProductRepository();
        //    var product = new Product { ProductId = 4, Name = "Test", Category = new Category { CategoryName = "", CategoryId = 1 } };
        //    repository.Add(ref product);
        //    var controller = new HomeController(null, repository);
        //    var productId = 4;
        //    var newCategoryName = "testing";

        //    var queryCategory = new QueryCategory();
        //    queryCategory.CategoryName = "newCategoryName";

        //    var queryProduct = new QueryProduct();
        //    queryProduct.ProductId = productId;
        //    queryProduct.Name = "newName";
        //    queryProduct.QueryCategory = queryCategory;

        //    // Act
        //    controller.UpdateProduct(queryProduct);

        //    // Assert
        //    Assert.IsTrue(repository.SaveChangesHasBeenCalled);
        }
    }
}
