using MobiWeather.Common;
using MobiWeather.Helpers;
using MobiWeather.Models.Contracts;
using MobiWeather.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobiWeather.ViewModels
{
    public class LoginViewModel : BindableObject
    {
        private readonly IAuthService _authService;

        public LoginViewModel()
        {
            _authService = DependencyService.Get<IAuthService>();

            LoginCommand = new Command(Login);
            SwitchToRegisterCommand = new Command(SwitchToRegister);
        }

        private async void SwitchToRegister(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
        }

        private async void Login(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(CurrentWeatherPage)}");

            //if (string.IsNullOrEmpty(UserName) 
            //    || string.IsNullOrEmpty(Password))
            //{
            //    PopupHelper.DisplayMessage("Fields cannot be empty", "Incorrect data");
            //    return;
            //}

            //try
            //{
            //    await _authService.Login(new LoginContract
            //    {
            //        Username = UserName,
            //        Password = Password
            //    });
            //}
            //catch (Exception ex)
            //{
            //    PopupHelper.DisplayMessage(ex.Message, "Login error");
            //}
        }

        private string _userName;
        private string _password;

        public string UserName
        {
            get => _userName;
            set
            {
                if (value != _userName)
                {
                    _userName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                if (value != _password)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand SwitchToRegisterCommand { get; }
    }
}
