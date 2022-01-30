using System.Collections.Generic;

namespace AnaMaria_Pupeza_Proiect.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
