using System;
using System.Collections.Generic;

namespace Asp.net_GraphQL.DataAccess
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int FlowerBouquetId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }

        public virtual FlowerBouquet FlowerBouquet { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
