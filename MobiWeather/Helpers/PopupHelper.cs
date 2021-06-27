using MobiWeather.ViewModels;
using MobiWeather.Views;
using Rg.Plugins.Popup.Extensions;

namespace MobiWeather.Helpers
{
    public class PopupHelper
    {
        public static async void DisplayMessage(string message, string title)
        {
            var pop = new PopupInfo
            {
                BindingContext = new PopupInfoViewModel()
                {
                    Message = message,
                    Title = title
                }
            };

            await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
            return;
        }
    }
}
