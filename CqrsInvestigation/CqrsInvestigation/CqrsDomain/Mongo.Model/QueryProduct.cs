namespace CqrsDomain.Mongo.Model
{
    public class QueryProduct
    {
        #region Properties

        public int _id { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public int SupplierId { get; set; }

        public QuerySupplier QuerySupplier { get; set; }

        public int CategoryId { get; set; }

        public QueryCategory QueryCategory { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        #endregion

    }

    public class QueryCategory
    {
        #region Properties

        //public BsonInt32 _id { get; set; }
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
        #endregion
    }

    public class QuerySupplier
    {
        #region Properties

        //public BsonInt32 _id { get; set; }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string HomePage { get; set; }
        #endregion
    }
}
