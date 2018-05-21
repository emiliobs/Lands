﻿namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using Xamarin.Forms;


    public class LoginViewModel : BaseViewModel
    {
        #region Atributtes
        string email;
        string password;
        bool isRunning;
        bool isEnabled;
      
        #endregion

        #region Properties
        public string Email
        {
            get => email;
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Password
        {
            get => password;
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsRunning
        {
            get => isRunning;
            set
            {
                if (isRunning != value)
                {
                    isRunning = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsRemembered
        {
            get;
            set;
            
        }
        public bool IsEnabled
        {
            get => isEnabled;
            set
            {
                if (isEnabled != value)
                {
                    isEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Constructor
        public LoginViewModel()
        {
            this.IsRemembered = true;
            IsEnabled = true;
            
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get => new RelayCommand(Login);
        }

       

        #endregion

        #region Methods

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error","You must enter an Email..","Accept");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error","You must enter a Password.","Accept");
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            if (Email != "emilio@gmail.com" || Password != "emilio123.")
            {

                IsRunning = false;
                IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert("Error", "Email or Password incorreect.", "Accept");

                
                Password = string.Empty;
               
                return;
            }

            IsRunning = false;
            IsEnabled = true;

            await Application.Current.MainPage.DisplayAlert("OK", "Fuck yeahhhh", "Accept");
            
        }

        #endregion

       


    }
}
