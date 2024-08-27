using LiveCharts.Wpf;
using LiveCharts;
using System.Windows.Controls;
using System.Windows.Media;

namespace P_Finance.UI.Components
{
    /// <summary>
    /// Interaction logic for LineChart.xaml
    /// </summary>
    public partial class LineChart : UserControl
    {
        public SeriesCollection SeriesCollection { get; set; }

        public LineChart()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection();

            PopulateChartData();
        }

        private void PopulateChartData()
        {
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<double> { 3, 5, 7, 4, 5, 6, 7, 8, 9, 10, 8 },
                    PointGeometry = null, // No points
                    LineSmoothness = 0,
                    Stroke = Brushes.Red,// straight lines
                    StrokeThickness = 1,
                    Fill = System.Windows.Media.Brushes.Transparent// thin lines
                },

                new LineSeries
                {
                    Values = new ChartValues<double> { 2, 4, 6, 3, 4, 5, 6, 7, 8, 9, 7  },
                    PointGeometry = null, // No points
                    LineSmoothness = 0,
                    Stroke = Brushes.Green,// straight lines
                    StrokeThickness = 1,
                    Fill = System.Windows.Media.Brushes.Transparent// thin lines
                },

                new LineSeries
                {
                    Values = new ChartValues<double> { 3, 5, 7, 4, 15, 5, 4, 3, 6, 10, 8 },
                    PointGeometry = null, // No points
                    LineSmoothness = 0,
                    Stroke = Brushes.Yellow,// straight lines
                    StrokeThickness = 1,
                    Fill = System.Windows.Media.Brushes.Transparent// thin lines
                },

                new LineSeries
                {
                    Values = new ChartValues<double> { 13, 15, 7, 14, 5, 15, 4, 3, 6, 1, 8 },
                    PointGeometry = null, // No points
                    LineSmoothness = 0,
                    Stroke = Brushes.Blue,// straight lines
                    StrokeThickness = 1,
                    Fill = System.Windows.Media.Brushes.Transparent// thin lines
                }
            };

            DataContext = this;
        }
    }
}
