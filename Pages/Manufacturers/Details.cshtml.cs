using AnaMaria_Pupeza_Proiect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AnaMaria_Pupeza_Proiect.Pages.Manufacturers
{
    public class DetailsModel : PageModel
    {
        private readonly AnaMaria_Pupeza_Proiect.Data.AnaMaria_Pupeza_ProiectContext _context;

        public DetailsModel(AnaMaria_Pupeza_Proiect.Data.AnaMaria_Pupeza_ProiectContext context)
        {
            _context = context;
        }

        public Manufacturer Manufacturer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Manufacturer = await _context.Manufacturer.FirstOrDefaultAsync(m => m.ID == id);

            if (Manufacturer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
