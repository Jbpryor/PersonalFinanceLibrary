using P_Finance.UI.Stores;
using P_Finance.UI.ViewModels;
using P_Finance.Core.Models;
using P_Finance.Core;
using System.ComponentModel;

namespace P_Finance.UI.Commands
{
    public class NewDepositCommand : AsyncCommandBase
    {
        private readonly NewDepositViewModel _viewModel;
        private readonly ModalNavStore _modalNavStore;

        public static event Action? DepositCreated;

        public NewDepositCommand(NewDepositViewModel viewModel, ModalNavStore modalNavStore)
        {
            _viewModel = viewModel;
            _modalNavStore = modalNavStore;

            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(NewDepositViewModel.CanMakeDeposit))
            {
                OnCanExecutedChanged();
            }
        }

        public override async Task ExecuteAsync(object parameter)
        {
            DepositModel deposit = new()
            {
                Name = _viewModel.Name,
                Amount = _viewModel.Amount,
                CategoryId = _viewModel.SelectedCategory!.Id,
            };

            await GlobalConfig.Connection!.CreateDeposit(deposit);

            DepositCreated?.Invoke();

            _modalNavStore.CloseModal();
        }
    }
}
