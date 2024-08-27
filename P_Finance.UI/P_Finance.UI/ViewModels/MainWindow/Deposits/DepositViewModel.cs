using P_Finance.UI.Services;
using P_Finance.Core.Models;

namespace P_Finance.UI.ViewModels
{
    public class DepositViewModel : ViewModelBase, IAmountService
    {
        private readonly DepositModel _deposit;


        public int Id => _deposit.Id;
        public DateTime Date => _deposit.Date;
        public string? Name => _deposit.Name;
        public int CategoryId => _deposit.CategoryId;
        public decimal Amount => _deposit.Amount;
        public string? CategoryName => DepositCategoryModel.GetCategoryNameById(CategoryId);


        public DepositViewModel(DepositModel deposit)
        {
            _deposit = deposit;
        }
    }
}
