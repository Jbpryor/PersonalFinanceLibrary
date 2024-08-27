namespace P_Finance.Core.Models
{
    public class CreditCardModel
    {
        public int Id { get; set; }
        public string? CardName { get; set; }
        public string? BalanceTotal { get; set; }
        public List<PurchaseModel> Purchases { get; set; } = [];
    }
}
