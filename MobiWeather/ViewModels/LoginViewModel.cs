using MobiWeather.Helpers;
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
        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
            SwitchToRegisterCommand = new Command(SwitchToRegister);
        }

        private async void SwitchToRegister(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
        }

        private void Login(object obj)
        {
            if (string.IsNullOrEmpty(UserName) 
                || string.IsNullOrEmpty(Password))
            {
                PopupHelper.DisplayMessage("Fields cannot be empty", "Incorrect data");
                return;
            }
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
