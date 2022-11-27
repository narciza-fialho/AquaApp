using AquaApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace AquaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroPage : ContentPage
    {
        public RegistroViewModel registroView { get; set; }

        public RegistroPage()
        {
            InitializeComponent();
            registroView = new RegistroViewModel();
            listaRegistro.ItemsSource = registroView.RetornaRegistros();
            
        }

        protected override void OnAppearing()
        {
            var retorno = registroView.RetornaRegistroBool();
            if (retorno == "true")
            {
                this.ButtonFecha.IsVisible = true;
                this.ButtonNaoFecha.IsVisible = true;
            } 
            else if (retorno == "ultimo")
            {
                this.ButtonFecha.IsVisible = false;
                this.ButtonNaoFecha.IsVisible = true;
            } 
            else if (retorno == "false")
            {
                this.ButtonFecha.IsVisible = false;
                this.ButtonNaoFecha.IsVisible = false;
            }
        }

        void BotaoNaoFeche(object sender, EventArgs e)
        {
            registroView.RespondeRegistroNaoFecha();
            Navigation.PushAsync(new InicioPage());
        }

        void BotaoFeche(object sender, EventArgs e)
        {
            registroView.RespondeRegistroFecha();
            Navigation.PushAsync(new InicioPage());
        }
    }
}