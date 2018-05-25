namespace Lands.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Lands.Models;
    using Lands.Views;
    using Xamarin.Forms;

    public class LandItemViewModel: Land
    {
        #region Properties

        public ICommand SelectLandCommand { get => new RelayCommand(SelectLand); }

        #endregion


        #region Methods

        private async void SelectLand()
        {
            MainViewModel.GetInstance().Land = new LandViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new LandTabbedPage());
        }

        #endregion
    }
}
