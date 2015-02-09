namespace CqrsDomain.Northwind.Model
{
    public class OrderDetail
    {
        #region Properties
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public decimal UnitPrice { get; set; }

        public short Quantity { get; set; }

        public float Discount { get; set; }
        #endregion
    }
}
