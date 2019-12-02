using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Restaurant.Model.Entities
{
    public class OrderItem : INotifyPropertyChanged
    {
        public OrderItem()
        {
            _orderItemOptions = new List<OrderItemOption>();
        }

        public OrderItem(Product product, int quantity)
            : this()
        {
            ProductId = product.Id;
            Product = product;
            UnitPrice = product.Price;
            Quantity = quantity;
        }

        public OrderItem(Product product,decimal price, int quantity)
            : this()
        {
            ProductId = product.Id;
            Product = product;
            UnitPrice = price;
            Quantity = quantity;
        }

        public long Id { get; set; }
        public long OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        private List<OrderItemOption> _orderItemOptions;
        public List<OrderItemOption> OrderItemOptions
        {
            get
            {
                return _orderItemOptions;
            }
            set
            {
                _orderItemOptions = value;
                PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(nameof(OrderItemOptions)));
            }
        }
        public Product Product { get; set; }
        public Order Order { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = delegate {};


        public decimal Total()
        {
            decimal total = 0.0m;
            if(OrderItemOptions != null)
            {
                foreach (var option in OrderItemOptions)
                {
                    total += option.Price * option.Quantity;
                }
            }

            total += UnitPrice * Quantity;
            return total;
        }

        public int GetOrderItemOptionCount()
        {
            return OrderItemOptions.Count;
        }
    }
}
