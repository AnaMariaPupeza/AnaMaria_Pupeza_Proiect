using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnaMaria_Pupeza_Proiect.Models
{
    public class Product
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public Manufacturer Manufacturer { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
