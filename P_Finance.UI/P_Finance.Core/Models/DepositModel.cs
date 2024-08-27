namespace P_Finance.Core.Models
{
    public class DepositModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }

        public string? CategoryName
        {
            get
            {
                return DepositCategoryModel.GetCategoryNameById(CategoryId);
            }
        }
    }
}
