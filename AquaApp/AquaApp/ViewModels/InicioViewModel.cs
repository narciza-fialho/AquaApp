using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AquaApp.ViewModels
{
    public class InicioViewModel : BaseViewModel
    {
        public InicioViewModel() 
        {
            Title = "Aqua App";

            /* Não funciona esse
            var consumoAtualFrame = "5 m3";
            var consumoPassadoFrame = "15 m3";

            Esse não sei usar
            Frame consumoAtualFrame = new Frame
            {
                Content = new Label { Text = "5 m3" }
            };

            Frame consumoPassadoFrame = new Frame
            {
                Content = new Label { Text = "15 m3" }
            };*/

            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}
