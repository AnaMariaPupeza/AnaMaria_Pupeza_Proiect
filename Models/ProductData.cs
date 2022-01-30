using System.Collections.Generic;

namespace AnaMaria_Pupeza_Proiect.Models
{
    public class ProductData
    {
        public IEnumerable<Product> Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
