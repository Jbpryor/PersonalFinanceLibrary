using P_Finance.UI.Commands;
using P_Finance.UI.Services;
using P_Finance.UI.Stores;
using P_Finance.Core.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace P_Finance.UI.ViewModels;

public class NewDepositViewModel : ViewModelBase
{
    private readonly ObservableCollection<DepositCategoryModel> _categories;
    public IEnumerable<DepositCategoryModel> Categories => _categories;
    private readonly ModalNavStore _modalNavStore;



    private string? _name;
    public string? Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    private decimal _amount;
    public decimal Amount
    {
        get
        {
            return _amount;
        }
        set
        {
            _amount = value;
            OnPropertyChanged(nameof(Amount));
        }
    }

    private DepositCategoryModel? _selectedCategory;
    public DepositCategoryModel? SelectedCategory
    {
        get { return _selectedCategory; }
        set
        {
            _selectedCategory = value;
            OnPropertyChanged(nameof(SelectedCategory));
            OnPropertyChanged(nameof(CanMakeDeposit));
        }
    }


    public AsyncCommandBase NewDepositCommand { get; }
    public ICommand CloseModalCommand { get; }

    public NewDepositViewModel(ModalNavStore modalNavStore)
    {
        _modalNavStore = modalNavStore;
        _categories = [];

        NewDepositCommand = new NewDepositCommand(this, _modalNavStore);
        CloseModalCommand = new CloseModalCommand(_modalNavStore);

        PopulateCategories();
    }


    private void PopulateCategories()
    {
        List<DepositCategoryModel> _categoryList = [.. DepositCategoryModel.Categories().OrderBy(category => category.Name)];

        foreach (DepositCategoryModel category in _categoryList)
        {
            _categories.Add(category);
        }
    }


    public bool CanMakeDeposit => HasEnteredName && HasAmountGreaterThanZero && HasSelectedCategory;
    private bool HasEnteredName => !string.IsNullOrEmpty(Name);
    private bool HasAmountGreaterThanZero => Amount > 0;
    private bool HasSelectedCategory => SelectedCategory != null;
}