using System.Linq;
using System.Web.Mvc;
using CqrsDal;
using CqrsDomain.Contracts;
using CqrsDomain.Mongo.Model;

namespace CqrsPoc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICommand _commandModel;
        private readonly IQuery _queryModel;

        public HomeController()
            : this(new MongoRepository(), new ProductsRepository()) // Poor mans IOC
        {

        }

        public HomeController(IQuery queryModel, ICommand commandModel)
        {
            _queryModel = queryModel;
            _commandModel = commandModel;
        }

        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetProducts()
        {
            var products = _queryModel.FindProducts();
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public void UpdateProduct(QueryProduct queryProduct)  
        {
            _commandModel.UpdateProduct(queryProduct);
        }
    }
}
