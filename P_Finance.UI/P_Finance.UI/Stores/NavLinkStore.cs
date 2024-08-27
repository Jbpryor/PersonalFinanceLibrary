using System.Windows.Input;

namespace P_Finance.UI.Stores
{
    public class NavLinkStore
    {
        public string? Text { get; set; }
        public ICommand? Command { get; set; }

        public NavLinkStore(string text, ICommand? command)
        {
            Text = text;
            Command = command;
        }
    }
}
