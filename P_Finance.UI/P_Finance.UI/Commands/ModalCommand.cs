using P_Finance.UI.Services;
using P_Finance.UI.ViewModels;

namespace P_Finance.UI.Commands
{
    public class ModalCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase
    {
        private readonly ModalNavService<TViewModel> _navService;

        public ModalCommand(ModalNavService<TViewModel> navService)
        {
            _navService = navService;
        }

        public override void Execute(object? parameter)
        {
            _navService.Navigate();
        }
    }
}
