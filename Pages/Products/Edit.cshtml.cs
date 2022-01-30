using AnaMaria_Pupeza_Proiect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AnaMaria_Pupeza_Proiect.Pages.Products
{
    public class EditModel : ProductCategoriesPageModels
    {
        private readonly AnaMaria_Pupeza_Proiect.Data.AnaMaria_Pupeza_ProiectContext _context;

        public EditModel(AnaMaria_Pupeza_Proiect.Data.AnaMaria_Pupeza_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product
                    .Include(b => b.Manufacturer)
                    .Include(b => b.ProductCategories).ThenInclude(b => b.Category)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.ID == id);

            if (Product == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Product);

            ViewData["ManufacturerID"] = new SelectList(_context.Set<Manufacturer>(),
               "Id", "ManufacturerName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {

            if (id == null)
            {
                return NotFound();
            }

            var productToUpdate = await _context.Product
                    .Include(i => i.Manufacturer)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .FirstOrDefaultAsync(s => s.ID == id);


            if (productToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Product>(productToUpdate, "Product",
                    i => i.Name, 
                    i => i.Price,
                    i => i.Manufacturer, 
                    i => i.ExpirationDate))
            {
                UpdateProductCategories(_context, selectedCategories, productToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateProductCategories(_context, selectedCategories, productToUpdate);
            PopulateAssignedCategoryData(_context, productToUpdate);
            return Page();
        }
    }
    
}
    

