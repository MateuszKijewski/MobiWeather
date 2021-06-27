using MobiWeather.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MobiWeather.Views
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