using P_Finance.UI.ViewModels;
using P_Finance.Core;
using P_Finance.Core.Models;
using System.Collections.ObjectModel;


namespace P_Finance.UI.Services
{
    public class CreditCardService
    {
        private static CreditCardService? _creditCardService;
        public static CreditCardService CardService => _creditCardService ??= new CreditCardService();

        private readonly ObservableCollection<CreditCardViewModel> _creditCards;

        public ObservableCollection<CreditCardViewModel> CreditCards => _creditCards;

        public CreditCardService()
        {
            _creditCards = new ObservableCollection<CreditCardViewModel>();
        }

        public async Task GetCreditCards()
        {
            var creditCardsFromDatabase = (await GlobalConfig.Connection!.CreditCards_GetAll()).OrderByDescending(card => card.Id);

            if (creditCardsFromDatabase != null)
            {
                CreditCards.Clear();
                foreach (CreditCardModel creditCard in creditCardsFromDatabase)
                {
                    CreditCards.Add(new CreditCardViewModel(creditCard));
                }
            }
        }
    }
}
