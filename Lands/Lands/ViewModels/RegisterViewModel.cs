namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Lands.Helpers;
    using Lands.Models;
    using Lands.Serivices;
    using Plugin.Media;
    using Plugin.Media.Abstractions;
    using System.Windows.Input;
    using Xamarin.Forms;
    



    public class RegisterViewModel : BaseViewModel
    {

        #region Services
        ApiService apiservice;
        #endregion

        #region Attributes
        bool isRunning;
        bool isEnabled;
        ImageSource imageSource;
        MediaFile file;
        #endregion

        #region Properties
        public ImageSource ImageSource
        {
            get => imageSource;
            set
            {
                if (imageSource != value)
                {
                    imageSource = value;
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

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Confirm { get; set; }

        #endregion

        #region Contructor

        public RegisterViewModel()
        {
            apiservice = new ApiService();

            IsEnabled = true;
            ImageSource = "No_image";
        }

        #endregion

        #region Commands
        public ICommand RegisterCommand { get => new RelayCommand(Register); }

        public ICommand ChangeImageCommand { get => new RelayCommand(ChangeImage); }


        #endregion

        #region Methods 
        private async void Register()
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.FirstNameValidation,
                    Languages.Accept);

                return;
            }

            if (string.IsNullOrEmpty(LastName))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.LastNameValidation,
                    Languages.Accept);

                return;
            }

            if (string.IsNullOrEmpty(Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.EmailValidation,
                    Languages.Accept);

                return;
            }

            //usi las expsion regular para validad de forma correcta el email:
            if (!RegexUtilities.IsValidEmail(Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.EmailValidation2,
                    Languages.Accept
                    );

                return;
            }

            if (string.IsNullOrEmpty(Phone))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.PhoneValidation,
                    Languages.Accept);

                return;
            }


            if (string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.PasswordValidation,
                    Languages.Accept);

                return;
            }

            //aqui valido que el password sea mayoe de 6 números:
            if (Password.Length < 6)
            {
                await Application.Current.MainPage.DisplayAlert(

                    Languages.Error,
                    Languages.PasswordValidation2,
                    Languages.Accept

                    );

                return;
            }

            if (string.IsNullOrEmpty(Confirm))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.ConfirmValidation,
                    Languages.Accept);

                return;
            }

            if (Password != Confirm)
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.EMail,
                    Languages.ConfirmValidation2,
                    Languages.Accept);

                return;
            }

            IsRunning = true;
            IsEnabled = false;

            var checkConnection = await apiservice.CheckConnection();

            if (!checkConnection.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(

                       Languages.Error,
                       checkConnection.Message,
                       Languages.Accept
                    );

                return;
            }

            byte[] imageArray = null;

            if (file != null)
            {
                imageArray = FileHelper.ReadFully(file.GetStream());
            }

            var user = new User()
            {

                Email = this.Email,
                FirstName = FirstName,
                LastName = LastName,
                Telephone = Phone,
                UserTypeId = 1,
                ImageArray = imageArray,
                Password = Password,

            };

            var apiSecurity = Application.Current.Resources["APISecurity"].ToString();
            var response = await apiservice.Post(apiSecurity, "/api", "/Users", user);

            if (!response.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    response.Message,
                     Languages.Accept);

                return;

            }

            IsRunning = false;
            IsEnabled = true;

            await Application.Current.MainPage.DisplayAlert(
                     Languages.ConfirmLabel,
                     Languages.UserRegisterMessage,
                      Languages.Accept);

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void ChangeImage()
        {
            await CrossMedia.Current.Initialize();

            if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
            {
                var source = await Application.Current.MainPage.DisplayActionSheet(

                    Languages.SourceImageQuestion,
                    Languages.Cancel,
                    null,
                    Languages.FromGallery,
                    Languages.FromCamera);

                if (source == Languages.Cancel)
                {
                    file = null;

                    return;
                }

                if (source == Languages.FromCamera)
                {
                    file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                    {

                        Directory = "Sample",
                        Name = "test.jpg",
                        PhotoSize = PhotoSize.Small,

                    });
                }
                else
                {
                    file = await CrossMedia.Current.PickPhotoAsync();
                }
            }
            else
            {
                file = await CrossMedia.Current.PickPhotoAsync();
            }

            if (file != null)
            {
                ImageSource = ImageSource.FromStream(() => {

                    var stream = file.GetStream();
                    return stream;

                });
            }
        }



        #endregion


    }
}
