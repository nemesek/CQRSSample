using System;

namespace CqrsDomain.Northwind.Model
{
    public class Order
    {
        #region Properties
        public int Id { get; set; }

        public string CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public DateTime? Date { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public string ShipCountry { get; set; }
        #endregion
    }
}
