using AquaApp.Models;
using AquaApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AquaApp.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }
        public NewItemViewModel viewModel { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            viewModel = new NewItemViewModel();
            BindingContext = new NewItemViewModel();
        }

        void BotaoPut(object sender, EventArgs e)
        {
            viewModel.RespondeRegistroFecha();
        }
    }
}