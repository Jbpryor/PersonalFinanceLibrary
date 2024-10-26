namespace P_Finance.Core.Models
{
    public class PurchaseCategoryModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public static List<PurchaseCategoryModel> Categories()
        {
            return new List<PurchaseCategoryModel>
            {
                new PurchaseCategoryModel { Id = 1, Name = "Gas" },
                new PurchaseCategoryModel { Id = 2, Name = "Groceries" },
                new PurchaseCategoryModel { Id = 3, Name = "General" },
                new PurchaseCategoryModel { Id = 4, Name = "Update Card Balance" },
                new PurchaseCategoryModel { Id = 5, Name = "Payment" },
                new PurchaseCategoryModel { Id = 6, Name = "Refund" },
                new PurchaseCategoryModel { Id = 7, Name = "Pet" },
                new PurchaseCategoryModel { Id = 8, Name = "Car Insurance" },
                new PurchaseCategoryModel { Id = 9, Name = "Phone" },
                new PurchaseCategoryModel { Id = 10, Name = "Vacation" },
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
