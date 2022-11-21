using AquaApp.Models;
using AquaApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AquaApp.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private ApiAccess apiAccess { get; set; }
        private string text;
        private string description;

        public NewItemViewModel()
        {
            apiAccess = new ApiAccess();
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Description = Description
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        public void RespondeRegistroFecha()
        {
            Registro registro = new Registro();
            registro.DataOcorrencia = DateTime.Now;
            registro.Decisao = false;
            
            if(apiAccess.IncluirRegistroAberto(registro))
            {
                Console.WriteLine("deu bom");
            }

        }
    }
}
