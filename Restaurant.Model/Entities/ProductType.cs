using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Restaurant.Model.Entities
{
    public class ProductType
    {
        public ProductType()
        {

        }

        public ProductType(string type)
        {
            Type = type;
        }

        public ProductType(int id, string type)
        {
            Id = id;
            Type = type;
        }
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Type { get; set; }
    }
}
