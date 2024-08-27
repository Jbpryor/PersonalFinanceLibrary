using P_Finance.UI.Stores;
using P_Finance.UI.ViewModels;
using P_Finance.Core.Models;
using P_Finance.Core;
using System.ComponentModel;


namespace P_Finance.UI.Commands
{
    public class NewPurchaseCommand : AsyncCommandBase
    {
        private readonly NewPurchaseViewModel _viewModel;
        private readonly ModalNavStore _modalNavStore;

        public static event Action? PurchaseCreated;

        public NewPurchaseCommand(NewPurchaseViewModel viewModel, ModalNavStore modalNavStore)
        {
            _viewModel = viewModel;
            _modalNavStore = modalNavStore;

            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(NewPurchaseViewModel.CanMakePurchase))
            {
                OnCanExecutedChanged();
            }
        }

        public override async Task ExecuteAsync(object parameter)
        {
            CreditCardViewModel? selectedCard = _viewModel.SelectedCard;

            PurchaseModel purchase = new()
            {
                Name = _viewModel.Name,
                CategoryId = _viewModel.SelectedCategory!.Id,
                Amount = _viewModel.Amount,
                CreditCardId = selectedCard!.Id
            };

            await GlobalConfig.Connection!.CreatePurchase(purchase);

            selectedCard.CreditCard.Purchases.Add(purchase);

            PurchaseCreated?.Invoke();

            _modalNavStore.CloseModal();
        }
    }
}
