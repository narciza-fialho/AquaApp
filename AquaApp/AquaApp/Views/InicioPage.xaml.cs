using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AquaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioPage : ContentPage
    {
        public InicioPage()
        {
            InitializeComponent();
        }

        public static readonly SKColor TextColor = SKColors.Black;

        public static Chart[] CreateXamarinSample()
        {
            var entries = new[]
            {
                new ChartEntry(16)
                {
                    Label = "08/22",
                    ValueLabel = "16",
                    Color = SKColor.Parse("#F0F8FF"),
                    TextColor = TextColor
                },
                new ChartEntry(15)
                {
                    Label = "09/22",
                    ValueLabel = "15",
                    Color = SKColor.Parse("#F0F8FF"),
                    TextColor = TextColor
                },
                new ChartEntry(17)
                {
                    Label = "10/22",
                    ValueLabel = "17",
                    Color = SKColor.Parse("#F0F8FF"),
                    TextColor = TextColor
                },
                new ChartEntry(15)
                {
                    Label = "11/22",
                    ValueLabel = "15",
                    Color = SKColor.Parse("#F0F8FF"),
                    TextColor = TextColor
                }
            };

            return new Chart[]
            {                
                new LineChart()
                {
                    Entries = entries,
                    LineMode = LineMode.Straight,
                    LineSize = 8,
                    PointMode = PointMode.Circle,
                    PointSize = 18,
                    LabelTextSize = 35,
                    BackgroundColor = SKColor.Parse("#B0C4DE")
                }
            };

        }

        protected override void OnAppearing()
        {
            var charts = CreateXamarinSample();
            this.chart.Chart = charts[0];
        }
    }
}