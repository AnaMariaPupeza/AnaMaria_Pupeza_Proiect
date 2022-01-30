using AnaMaria_Pupeza_Proiect.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnaMaria_Pupeza_Proiect.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly AnaMaria_Pupeza_Proiect.Data.AnaMaria_Pupeza_ProiectContext _context;

        public IndexModel(AnaMaria_Pupeza_Proiect.Data.AnaMaria_Pupeza_ProiectContext context)
        {
            _context = context;
        }
        public IList<Product> Product { get; set; }
        public ProductData ProductD { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            ProductD = new ProductData();

            ProductD.Product = await _context.Product
            .Include(b => b.Manufacturer)
            .Include(b => b.ProductCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();

            if (id != null)
            {
                ProductID = id.Value;
                Product product = ProductD.Product
                .Where(i => i.ID == id.Value).Single();
                ProductD.Categories = product.ProductCategories.Select(s => s.Category);

            }

        }
    }
}
