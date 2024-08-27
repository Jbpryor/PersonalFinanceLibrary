using P_Finance.UI.Stores;
using P_Finance.UI.ViewModels;
using P_Finance.Core;
using P_Finance.Core.Models;
using System.ComponentModel;

namespace P_Finance.UI.Commands
{
    public class NewCreditCardCommand : AsyncCommandBase
    {
        private readonly NewCardViewModel _viewModel;
        private readonly ModalNavStore _modalNavStore;

        public static event Action? NewCardCreated;

        public NewCreditCardCommand(NewCardViewModel viewModel, ModalNavStore modalNavStore)
        {
            _viewModel = viewModel;
            _modalNavStore = modalNavStore;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(NewCardViewModel.CanCreateNewCard))
            {
                OnCanExecutedChanged();
            }
        }

        public override async Task ExecuteAsync(object parameter)
        {
            CreditCardModel card = new CreditCardModel
            {
                CardName = _viewModel.CardName,
            };

            await GlobalConfig.Connection!.CreateCreditCard(card);

            _viewModel.CardName = string.Empty;

            NewCardCreated?.Invoke();

            _modalNavStore.CloseModal();
        }
    }
}
