using AnaMaria_Pupeza_Proiect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnaMaria_Pupeza_Proiect.Pages.Products
{
    public class CreateModel : ProductCategoriesPageModels
    {
        private readonly AnaMaria_Pupeza_Proiect.Data.AnaMaria_Pupeza_ProiectContext _context;

        public CreateModel(AnaMaria_Pupeza_Proiect.Data.AnaMaria_Pupeza_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ManufacturerID"] = new SelectList(_context.Set<Manufacturer>(),
                "Id", "ManufacturerName");
            var product = new Product();
            product.ProductCategories = new List<ProductCategory>();
            PopulateAssignedCategoryData(_context, product);
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            /* if (!ModelState.IsValid)
             {
                 return Page();
             }

             _context.Product.Add(Product);
             await _context.SaveChangesAsync();

             return RedirectToPage("./Index");
            */
            var newProduct = new Product();
            if (selectedCategories != null)
            {
                newProduct.ProductCategories = new List<ProductCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ProductCategory
                    {
                        CategoryId = int.Parse(cat)
                    };
                    newProduct.ProductCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Product>(
            newProduct,
            "Product",
            i => i.Name, i => i.Price,
            i => i.Manufacturer, i => i.ExpirationDate))
            {
                _context.Product.Add(newProduct);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newProduct);
            return Page();

        }
    }
}
