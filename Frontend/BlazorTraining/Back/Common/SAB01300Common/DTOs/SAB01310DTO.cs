using System;

namespace SAB01300Common.DTOs
{
    public class SAB01310DTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
    }
}
