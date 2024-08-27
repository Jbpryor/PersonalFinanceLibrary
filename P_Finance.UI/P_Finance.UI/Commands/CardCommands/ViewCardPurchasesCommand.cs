using P_Finance.UI.Services;
using P_Finance.UI.ViewModels;

namespace P_Finance.UI.Commands;

public class ViewCardPurchasesCommand : CommandBase
{
    private readonly CreditCardViewModel _viewModel;
    private readonly ParamNavService<CreditCardViewModel, CreditCardViewModel> _paramNavService;

    public ViewCardPurchasesCommand(CreditCardViewModel viewModel, ParamNavService<CreditCardViewModel, CreditCardViewModel> paramNavService)
    {
        _viewModel = viewModel;
        _paramNavService = paramNavService;
    }

    public override void Execute(object? parameter)
    {
        _paramNavService.Navigate(_viewModel);
    }
}
