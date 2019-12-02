using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Restaurant.Model.Entities
{
    public class ProductOption : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ProductType ProductType { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
