using System;

namespace Restaurant.Model.ModelWrappers
{
    public class OrderInfo
    {
        public long OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public decimal AmountTotal { get; set; }

    }
}
