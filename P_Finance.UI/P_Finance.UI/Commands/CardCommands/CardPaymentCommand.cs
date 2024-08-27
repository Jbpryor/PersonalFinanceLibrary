using P_Finance.Core.Models;
using P_Finance.Core;
using System.ComponentModel;
using P_Finance.UI.ViewModels;
using P_Finance.UI.Stores;

namespace P_Finance.UI.Commands
{
    public class CardPaymentCommand : AsyncCommandBase
    {
        private readonly CardPaymentViewModel _viewModel;
        private readonly ModalNavStore _modalNavStore;

        public static event Action? PaymentCreated;

        public CardPaymentCommand(CardPaymentViewModel viewModel, ModalNavStore modalNavStore)
        {
            _viewModel = viewModel;
            _modalNavStore = modalNavStore;

            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CardPaymentViewModel.CanMakePayment))
            {
                OnCanExecutedChanged();
            }
        }

        public override async Task ExecuteAsync(object parameter)
        {
            CreditCardViewModel? selectedCard = _viewModel.SelectedCard;

            PurchaseModel payment = new()
            {
                Name = "Credit Card Payment",
                CategoryId = 5,
                Amount = _viewModel.Amount,
                CreditCardId = selectedCard!.Id
            };

            await GlobalConfig.Connection!.CreatePurchase(payment);

            selectedCard.CreditCard.Purchases.Add(payment);

            PaymentCreated?.Invoke();

            _modalNavStore.CloseModal();
        }
    }
}
