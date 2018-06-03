namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Lands.Views;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MenuItemViewModel
    {
        #region Properties
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }
        #endregion

        #region Commands

        public ICommand NavigateCommand { get => new RelayCommand(Navigate); }

        #region Methods
        private void Navigate()
        {
            if (PageName == "LoginPage")
            {
                Application.Current.MainPage = new LoginPage();
            }
        } 
        #endregion

        #endregion


    }
}
