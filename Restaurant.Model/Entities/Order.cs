using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Model.Entities
{
    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
        public Order(Comment comment, List<OrderItem> orderItems)
            : this()
        {
            Comment = comment;
            OrderDate = DateTime.Now;
            OrderItems = orderItems;
        }

        public long Id { get; set; }
        //public Guid CustomerId { get; set; }
        public long CommentId { get; set; }
        public int ItemsTotal { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public Comment Comment { get; set; }
        //public Customer Customer { get; set; }

        public int GetOrderItemsCount()
        {
            return OrderItems.Count;
        }
        public decimal Total()
        {
            decimal total = 0m;
            foreach(var item in OrderItems)
            {
                total += item.Total();
            }
            return total;
        }
        
    }
}
