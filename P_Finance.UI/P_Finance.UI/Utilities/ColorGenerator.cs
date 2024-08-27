using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace P_Finance.UI.Utilities
{
    public class ColorGenerator : IValueConverter
    {
        public ColorGenerator()
        {
            
        }

        private static readonly Color[] brightColors =
{
            Color.FromRgb(135, 200, 48),  // Bright green
            Color.FromRgb(255, 212, 0),   // Bright yellow
            Color.FromRgb(254, 126, 15),  // Bright orange
            Color.FromRgb(142, 60, 203),  // Bright purple
            Color.FromRgb(227, 0, 255),   // Bright magenta
            Color.FromRgb(176, 255, 0),   // Bright lime green
            Color.FromRgb(0, 255, 210),   // Bright cyan
            Color.FromRgb(253, 255, 0),   // Bright lemon yellow
            Color.FromRgb(255, 49, 85),   // Bright red
            Color.FromRgb(255, 175, 66),  // Bright coral
            Color.FromRgb(255, 237, 94),  // Bright yellowish
            Color.FromRgb(73, 247, 112),  // Bright mint green
            Color.FromRgb(45, 174, 253)   // Bright sky blue
        };

        private static int currentIndex = 0;

        public static SolidColorBrush GenerateColor()
        {
            Color color = brightColors[currentIndex];
            currentIndex = (currentIndex + 1) % brightColors.Length;
            return new SolidColorBrush(color);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GenerateColor();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
