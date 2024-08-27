namespace P_Finance.Core.Models
{
    public class DepositCategoryModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public static List<DepositCategoryModel> Categories()
        {
            return new List<DepositCategoryModel>
            {
                new DepositCategoryModel { Id = 1, Name = "Cash" },
                new DepositCategoryModel { Id = 2, Name = "Paycheck" },
                new DepositCategoryModel { Id = 3, Name = "Bonus" },
                new DepositCategoryModel { Id = 4, Name = "ExtraCheck" },
                new DepositCategoryModel { Id = 5, Name = "Other" },
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
