using LiveCharts.Wpf;
using LiveCharts;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using P_Finance.UI.Utilities;
using P_Finance.UI.Services;

namespace P_Finance.UI.Components
{
    public partial class MiniLineChart : UserControl
    {
        public SeriesCollection SeriesCollection { get; set; }

        public static readonly DependencyProperty DataPointsProperty = DependencyProperty.Register("DataPoints", typeof(object), typeof(MiniLineChart), new PropertyMetadata(null, OnDataPointsChanged));

        public MiniLineChart()
        {
            InitializeComponent();

            DataContext = this;

            SeriesCollection = new SeriesCollection();

            PopulateChartData();
        }

        private static void OnDataPointsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var chart = d as MiniLineChart;
            chart?.PopulateChartData();
        }

        private void PopulateChartData()
        {
            if (DataPoints is IEnumerable<IAmountService> amountProviders && amountProviders.Any())
            {
                SeriesCollection.Clear();

                var amountValues = amountProviders.Select(point => (double)point.Amount).ToArray().Reverse();

                SeriesCollection.Add(new LineSeries
                {
                    Values = new ChartValues<double>(amountValues),
                    PointGeometry = null,
                    LineSmoothness = 0,
                    StrokeThickness = 1,
                    Fill = Brushes.Transparent,
                    ToolTip = null,
                    Stroke = ColorGenerator.GenerateColor()
                });
            }
        }

        public object DataPoints
        {
            get { return (object)GetValue(DataPointsProperty); }
            set { SetValue(DataPointsProperty, value); }
        }
    }
}
