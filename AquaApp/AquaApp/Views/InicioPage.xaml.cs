using AquaApp.Models;
using AquaApp.ViewModels;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AquaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioPage : ContentPage
    {
        public InicioViewModel inicioView { get; set; }

        public InicioPage()
        {
            InitializeComponent();
            inicioView = new InicioViewModel();
            BindingContext = new InicioViewModel();
        }

        protected override void OnAppearing()
        {
            var charts = inicioView.GraficoConsumo();
            this.chart.Chart = charts;
        }

        void NavigateTo(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistroPage());
        }
    }
}