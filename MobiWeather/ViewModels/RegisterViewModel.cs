using MobiWeather.Helpers;
using MobiWeather.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobiWeather.ViewModels
{
    public class RegisterViewModel : BindableObject
    {
        public RegisterViewModel()
        {
            RegisterCommand = new Command(Register);
            SwitchToLoginCommand = new Command(SwitchToLogin);
        }

        private async void SwitchToLogin(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
        }

        private void Register(object obj)
        {
            if (string.IsNullOrEmpty(UserName)
                || string.IsNullOrEmpty(Password)
                || string.IsNullOrEmpty(ConfirmPassword)
                || string.IsNullOrEmpty(FirstName)
                || string.IsNullOrEmpty(LastName))
            {
                PopupHelper.DisplayMessage("Fields cannot be empty", "Incorrect data");
                return;
            }
        }

        public ICommand RegisterCommand { get; }
        public ICommand SwitchToLoginCommand { get; }

        private string _userName;
        private string _password;
        private string _confirmPassword;
        private string _firstName;
        private string _lastName;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                    OnPropertyChanged(UserName);
                }
            }

        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    OnPropertyChanged(UserName);
                }
            }

        }

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

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                if (value != _confirmPassword)
                {
                    _confirmPassword = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
