using AutoMapper;
using CqrsDal.Concrete;
using CqrsDal.Contracts;
using CqrsDomain.Contracts;
using CqrsDomain.Mongo.Model;
using CqrsDomain.Northwind.Model;

namespace CqrsDal
{
    public class ModelSynchronizer
    {
        private readonly IMongoRepository _queryRepository;
        private readonly IPushProductMessages _messageDispatcher;

        public ModelSynchronizer()
        {
            CreateTypeMaps();
            _queryRepository = new MongoRepository();
            _messageDispatcher = new ProductMessagePusher();
        }

        public ModelSynchronizer(IMongoRepository queryRepository, IPushProductMessages messageDispatcher)
        {
            CreateTypeMaps();
            _queryRepository = queryRepository;
            _messageDispatcher = messageDispatcher;
        }

        private static void CreateTypeMaps()
        {
            Mapper.CreateMap<Supplier, QuerySupplier>();
            Mapper.CreateMap<Category, QueryCategory>();
            Mapper.CreateMap<Product, QueryProduct>().ForMember(qp => qp._id, m => m.MapFrom(p => p.ProductId))
                .ForMember(qp => qp.QueryCategory, m => m.MapFrom(p => p.Category))
                .ForMember(qp => qp.QuerySupplier, m => m.MapFrom(p => p.Supplier));
        }


        public QueryProduct MapProductToQueryProduct(Product product)
        {
            QueryProduct queryProduct = null;
            try
            {
                queryProduct = Mapper.Map<Product, QueryProduct>(product);  

            }
            catch (AutoMapperMappingException ex)
            {
                var message = ex.Message;
                throw;
            }
            return queryProduct;
        }

        public void UpdateQueryProduct(Product product)
        {
            var queryObject = this.MapProductToQueryProduct(product);

            _queryRepository.UpdateProduct(queryObject);
            _messageDispatcher.PushUpdatedProduct(queryObject); // updates the UI
        }

        public void ResetProductTable()
        {
            _messageDispatcher.ResetProductTable();
        }
    }
}
