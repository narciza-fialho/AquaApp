using AquaApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AquaApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}