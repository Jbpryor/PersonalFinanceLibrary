using P_Finance.UI.Stores;
using P_Finance.UI.ViewModels;
using P_Finance.Core;
using P_Finance.Core.Models;
using System.ComponentModel;

namespace P_Finance.UI.Commands
{
    public class RemoveCardCommand : AsyncCommandBase
    {
        private readonly RemoveCardViewModel _viewModel;
        private readonly ModalNavStore _modalNavStore;

        public static event Action? CardRemoved;

        public RemoveCardCommand(RemoveCardViewModel viewModel, ModalNavStore modalNavStore)
        {
            _viewModel = viewModel;
            _modalNavStore = modalNavStore;

            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RemoveCardViewModel.CanRemoveCard))
            {
                OnCanExecutedChanged();
            }
        }

        public override async Task ExecuteAsync(object parameter)
        {
            CreditCardViewModel? selectedCard = _viewModel.SelectedCard;

            CreditCardModel creditCard = new CreditCardModel
            {
                Id = selectedCard!.Id,
            };

            await GlobalConfig.Connection!.DeleteCreditCard(creditCard);

            CardRemoved?.Invoke();

            _viewModel.SelectedCard = null;

            _modalNavStore.CloseModal();
        }
    }
}
