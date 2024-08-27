using P_Finance.UI.Services;

namespace P_Finance.UI.Stores
{
    public class AmountStore : IAmountService
    {
        public decimal Amount { get; set; }

        public AmountStore(decimal amount)
        {
            Amount = amount;
        }
    }
}
