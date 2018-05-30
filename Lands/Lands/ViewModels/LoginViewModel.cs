namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Lands.Helpers;
    using Lands.Serivices;
    using Lands.Views;
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

            Email = "barrera_emilio@hotmail.com";
            Password= "Eabs-----55555";

            
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
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.EmailValidation,
                    Languages.Accept);
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert(Languages.Error,"You must enter a Password.",Languages.Accept);
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

            var token = await apiService.GetToken("http://landsapi5.azurewebsites.net", Email,Password);

            if (token == null)
            {
                IsRunning = false;
                IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(Languages.Error, "Something was Wrong.", Languages.Accept);

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

            var mainViewModel = MainViewModel.GetInstance();
            //aqui instancio el patron singleton:
            mainViewModel.Token = token;
            mainViewModel.Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());

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
