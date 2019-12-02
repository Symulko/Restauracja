using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Restaurant.Model.Entities
{
    public class Product : INotifyPropertyChanged
    {
        public Product()
        {
            ProductOptions = new List<ProductOption>();
        }
        public Product(int productId, ProductType productType, string name, decimal price)
            : this()
        {
            Id = productId;
            ProductType = productType;
            ProductTypeId = productType.Id;
            Name = name;
            Price = price;
        }

        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        [Required]
        [StringLength(70)]
        public string Name { get; set; }
        [StringLength(30)]
        public string Description { get; set; }
        [Required]
        [Range(0, 100)]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PictureUri { get; set; }

        public List<ProductOption> ProductOptions { get; set; }
        public ProductType ProductType { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
