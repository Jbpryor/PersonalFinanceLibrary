namespace P_Finance.Core.Models
{
    public class PurchasePowerModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int FromId { get; set; }
    }
}
