using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceLibrary.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public static List<CategoryModel> Categories()
        {
            return new List<CategoryModel>
            {
                new CategoryModel { Id = 1, Name = "Gas" },
                new CategoryModel { Id = 2, Name = "Groceries" },
                new CategoryModel { Id = 3, Name = "Other" },
                new CategoryModel { Id = 4, Name = "Update Card Balance" },
                new CategoryModel { Id = 5, Name = "Payment" },
                new CategoryModel { Id = 6, Name = "Refund" },
                new CategoryModel { Id = 7, Name = "Pet" },
                new CategoryModel { Id = 8, Name = "Car Insurance" },
                new CategoryModel { Id = 9, Name = "Phone" },
            };
        }

        public static Dictionary<int, string?> CategoryDictionary()
        {
            return Categories().ToDictionary(category => category.Id, category => category.Name);
        }

        public static string? GetCategoryNameById(int categoryId)
        {
            var categoryDictionary = CategoryDictionary();
            return categoryDictionary.TryGetValue(categoryId, out string? categoryName) ? categoryName : null;
        }
    }
}
