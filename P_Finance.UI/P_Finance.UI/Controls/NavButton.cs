using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls.Primitives;


namespace P_Finance.UI.Controls
{

    public class NavButton : ButtonBase 
    {
        static NavButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavButton), new FrameworkPropertyMetadata(typeof(NavButton)));
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(PackIconKind), typeof(NavButton), new PropertyMetadata(PackIconKind.None));
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(NavButton), new PropertyMetadata(null));

        public PackIconKind Icon
        {
            get { return (PackIconKind)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
}
