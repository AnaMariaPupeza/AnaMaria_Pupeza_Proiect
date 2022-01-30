using AnaMaria_Pupeza_Proiect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AnaMaria_Pupeza_Proiect.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly AnaMaria_Pupeza_Proiect.Data.AnaMaria_Pupeza_ProiectContext _context;

        public DetailsModel(AnaMaria_Pupeza_Proiect.Data.AnaMaria_Pupeza_ProiectContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.CategoryId == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
