using P_Finance.UI.Services;

namespace P_Finance.UI.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly INavigationService _navService;

        public NavigateCommand(INavigationService navService)
        {
            _navService = navService;
        }

        public override void Execute(object? parameter)
        {
            _navService.Navigate();
        }
    }    
}
