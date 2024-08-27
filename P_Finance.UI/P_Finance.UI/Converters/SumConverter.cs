using System.Collections;
using System.Globalization;
using System.Windows.Data;

namespace P_Finance.UI.Converters
{
    public class SumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable collection && parameter is string propertyName)
            {
                double sum = 0;

                foreach (var item in collection)
                {
                    var property = item.GetType().GetProperty(propertyName);
                    if (property != null)
                    {
                        var propertyValue = property.GetValue(item);
                        if (propertyValue is IConvertible convertible)
                        {
                            sum += convertible.ToDouble(CultureInfo.InvariantCulture);
                        }
                    }
                }

                return sum;
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
