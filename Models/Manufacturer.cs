using System.Collections.Generic;

namespace AnaMaria_Pupeza_Proiect.Models
{
    public class Manufacturer
    {
        public int ID { get; set; }
        public string ManufacturerName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
