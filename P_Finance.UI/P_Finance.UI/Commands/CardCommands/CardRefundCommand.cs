using P_Finance.Core.Models;
using P_Finance.Core;
using System.ComponentModel;
using P_Finance.UI.ViewModels;
using P_Finance.UI.Stores;

namespace P_Finance.UI.Commands
{
    public class CardRefundCommand : AsyncCommandBase
    {
        private readonly CardRefundViewModel _viewModel;
        private readonly ModalNavStore _modalNavStore;

        public static event Action? RefundCreated;

        public CardRefundCommand(CardRefundViewModel viewModel, ModalNavStore modalNavStore)
        {
            _viewModel = viewModel;
            _modalNavStore = modalNavStore;

            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CardRefundViewModel.CanCreateRefund))
            {
                OnCanExecutedChanged();
            }
        }

        public override async Task ExecuteAsync(object parameter)
        {
            CreditCardViewModel? selectedCard = _viewModel.SelectedCard;

            PurchaseModel refund = new()
            {
                Name = "Credit Card Refund",
                CategoryId = 6,
                Amount = _viewModel.Amount,
                CreditCardId = selectedCard!.Id
            };

            await GlobalConfig.Connection!.CreatePurchase(refund);

            selectedCard.CreditCard.Purchases.Add(refund);

            RefundCreated?.Invoke();

            _modalNavStore.CloseModal();
        }
    }
}
