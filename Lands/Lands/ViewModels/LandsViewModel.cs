namespace Lands.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using Lands.Serivices;
    using Models;
    using Xamarin.Forms;

    public class LandsViewModel : BaseViewModel
    {

        #region Services

        ApiService apiService;

        #endregion
        #region Atributtes

        private ObservableCollection<Land> lands;

        #endregion

        #region Properties

        //es observableCollection por que la voy a pintar en un listview:
        public ObservableCollection<Land> Lands
        {
            get => lands;
            set
            {
                if (lands != value)
                {
                    lands = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Contrustor

        public LandsViewModel()
        {
            apiService = new ApiService();
            LoadLands();
        }



        #endregion

        #region Methods
        private async void LoadLands()
        {
            var response = await apiService.GetList<Land>("http://restcountries.eu", "/rest", "/v2/all");

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
            }

            var list = (List<Land>)response.Result;

            this.Lands = new ObservableCollection<Land>(list);
        }
        #endregion
    }
}
