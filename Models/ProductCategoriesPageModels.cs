using AnaMaria_Pupeza_Proiect.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace AnaMaria_Pupeza_Proiect.Models
{
    public class ProductCategoriesPageModels : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(AnaMaria_Pupeza_ProiectContext context,
        Product product)
        {
            var allCategories = context.Category;
            var productCategories = new HashSet<int>(
            product.ProductCategories.Select(c => c.Id)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryId = cat.CategoryId,
                    Name = cat.CategoryName,
                    Assigned = productCategories.Contains(cat.CategoryId)
                });
            }
        }
        public void UpdateProductCategories(AnaMaria_Pupeza_ProiectContext context,
        string[] selectedCategories, Product productToUpdate)
        {
            if (selectedCategories == null)
            {
                productToUpdate.ProductCategories = new List<ProductCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var productCategories = new HashSet<int>
            (productToUpdate.ProductCategories.Select(c => c.CategoryId));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.CategoryId.ToString()))
                {
                    if (!productCategories.Contains(cat.CategoryId))
                    {
                        productToUpdate.ProductCategories.Add(
                        new ProductCategory
                        {
                            ProductId = productToUpdate.ID,
                            CategoryId = cat.CategoryId

                        });
                    }
                }
                else
                {
                    if (productCategories.Contains(cat.CategoryId))
                    {
                        ProductCategory courseToRemove
                        = productToUpdate
                        .ProductCategories
                        .SingleOrDefault(i => i.CategoryId == cat.CategoryId);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
