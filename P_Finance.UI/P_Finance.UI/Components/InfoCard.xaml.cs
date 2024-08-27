using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace P_Finance.UI.Components
{

    public partial class InfoCard : UserControl
    {
        public InfoCard()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(InfoCard));
        public static readonly DependencyProperty NumberProperty = DependencyProperty.Register("Number", typeof(string), typeof(InfoCard));
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(InfoCard), new PropertyMetadata(null));
        public static readonly DependencyProperty DataPointsProperty = DependencyProperty.Register("DataPoints", typeof(object), typeof(InfoCard), new PropertyMetadata(null));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public string Number
        {
            get { return (string)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public object DataPoints
        {
            get { return (object)GetValue(DataPointsProperty); }
            set { SetValue(DataPointsProperty, value); }
        }
    }
}
