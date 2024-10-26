using P_Finance.UI.Services;

namespace P_Finance.UI.Stores
{
    public class AmountStore : IAmountService
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public AmountStore(decimal amount)
        {
            Amount = amount;
        }

        public AmountStore(decimal amount, DateTime date)
        {
            Amount = amount;
            Date = date;
        }
    }
}
