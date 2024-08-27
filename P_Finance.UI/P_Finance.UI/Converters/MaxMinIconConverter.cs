using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows;

namespace P_Finance.UI.Converters
{
    public class MaxMinIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is WindowState state)
            {
                string imagePath = state == WindowState.Maximized
                    ? "/Resources/Images/restore.png"
                    : "/Resources/Images/maximize.png";

                return new BitmapImage(new Uri(imagePath, UriKind.Relative));
            }

            return new BitmapImage(new Uri("/Resources/Images/maximize.png", UriKind.Relative));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
