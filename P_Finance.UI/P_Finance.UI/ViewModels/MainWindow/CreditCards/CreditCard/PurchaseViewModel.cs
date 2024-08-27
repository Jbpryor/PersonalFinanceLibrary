using P_Finance.UI.Services;
using P_Finance.Core.Models;

namespace P_Finance.UI.ViewModels;

public class PurchaseViewModel : ViewModelBase, IAmountService
{

    private readonly PurchaseModel _purchase;


    public int Id => _purchase.Id;
    public DateTime Date => _purchase.Date;
    public string? Name => _purchase.Name;
    public int CategoryId => _purchase.CategoryId;
    public decimal Amount => _purchase.Amount;
    public int CreditCardId => _purchase.CreditCardId;
    public string? CategoryName => CategoryModel.GetCategoryNameById(CategoryId);



    public PurchaseViewModel(PurchaseModel purchase)
    {
        _purchase = purchase;
    }
}
