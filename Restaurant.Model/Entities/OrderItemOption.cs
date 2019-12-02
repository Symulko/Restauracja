using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Restaurant.Model.Entities
{
    public class OrderItemOption : INotifyPropertyChanged
    {
        private OrderItemOption()
        {

        }

        public OrderItemOption(int productOptionId, ProductOption productOption, decimal price, int quantity)
        {
            ProductOptionId = productOptionId;
            ProductOption = productOption;
            Price = price;
            Quantity = quantity;
        }
        public long Id { get; set; }
        public long OrderItemId { get; set; }
        public int ProductOptionId { get; set; }

        private int _quantity;
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(nameof(Quantity)));
            }
        }
        public decimal Price { get; set; }
        public OrderItem OrderItem { get; set; }
        public ProductOption ProductOption { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
