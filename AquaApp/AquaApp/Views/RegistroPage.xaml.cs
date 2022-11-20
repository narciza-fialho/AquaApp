using AquaApp.ViewModels;
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
    public partial class RegistroPage : ContentPage
    {
        public RegistroViewModel registroView { get; set; }

        public RegistroPage()
        {
            InitializeComponent();
            registroView = new RegistroViewModel();
            listaRegistro.ItemsSource = registroView.RetornaRegistros();
        }
    }
}