namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Lands.Helpers;
    using Lands.Serivices;
    using Lands.Views;
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using Xamarin.Forms;
    public class LoginViewModel : BaseViewModel
    {
        #region Services

        ApiService apiService;

        #endregion

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
            apiService = new ApiService();

            this.IsRemembered = true;
            IsEnabled = true;

            //Email = "barrera_emilio@hotmail.com";
            //Password= "Eabs-----55555";

            
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get => new RelayCommand(Login);
        }

        public ICommand RegisterCommand { get => new RelayCommand(Register); }

        private async void Register()
        {
            MainViewModel.GetInstance().Register = new RegisterViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }



        #endregion

        #region Methods

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.EmailValidation,
                    Languages.Accept);
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert(Languages.Error,
                                                                Languages.YouEnterPassword,Languages.Accept);
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(Languages.Error,connection.Message,Languages.Accept);
                return;
            }

            //aqui tengo la url no quemada esta en app.xaml
            var apiSecurity = Application.Current.Resources["APISecurity"].ToString();

            var token = await apiService.GetToken(apiSecurity, Email,Password);

            if (token == null)
            {
                IsRunning = false;
                IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(Languages.Error, Languages.SomethingWrong, Languages.Accept);

                return;
            }

            if (string.IsNullOrEmpty(token.AccessToken))
            {
                IsRunning = false;
                IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(Languages.Error, token.ErrorDescription, Languages.Accept);

                Password = string.Empty;

                return;
            }

            //aqui instancio el patron singleton:
            var mainViewModel = MainViewModel.GetInstance();
             ///aqui guardo el token en memoria
            mainViewModel.TokenId = token.AccessToken;
            mainViewModel.TokenTypeId = token.TokenType;

            if (IsRemembered)   
            {   
                //aqui guardo el token en persistencia
                Settings.TokenId = token.AccessToken;
                Settings.TokenTypeId = token.TokenType;

            }  

            mainViewModel.Lands = new LandsViewModel();
            //await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
            Application.Current.MainPage = new MasterPage();

            IsRunning = false;
            IsEnabled = true;
            
            

            Email = string.Empty;
            Password = string.Empty;

            //if (Email != Email || Password != Password)
            //{

            //    IsRunning = false;
            //    IsEnabled = true;

            //    await Application.Current.MainPage.DisplayAlert("Error", "Email or Password incorrect.", "Accept");


            // Password = string.Empty;

            //    return;
            //}        

            //await Application.Current.MainPage.DisplayAlert("OK", "Fuck yeahhhh", "Accept");

        }

        #endregion

       


    }
}
