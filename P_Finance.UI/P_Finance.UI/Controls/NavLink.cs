using System.Windows;
using System.Windows.Controls.Primitives;


namespace P_Finance.UI.Controls
{
    public class NavLink : ButtonBase
    {
        static NavLink()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavLink), new FrameworkPropertyMetadata(typeof(NavLink)));
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(NavLink), new PropertyMetadata(null));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
}
