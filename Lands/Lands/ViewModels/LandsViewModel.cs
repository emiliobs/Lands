namespace Lands.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Lands.Serivices;
    using Models;
    using Xamarin.Forms;

    public class LandsViewModel : BaseViewModel
    {

        #region Services

        ApiService apiService;

        #endregion

        #region Atributtes

        private ObservableCollection<LandItemViewModel> lands;

        bool isRefreshing;
        string filter;
       

        #endregion

        #region Properties

        //es observableCollection por que la voy a pintar en un listview:
        public ObservableCollection<LandItemViewModel> Lands
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

        public string Filter
        {
            get => filter;
            set
            {
                if (filter != value)
                {
                    filter = value;

                    OnPropertyChanged();

                    Search();
                }
            }
        }

        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                if (isRefreshing != value)
                {
                    isRefreshing = value;
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

        #region Commands

        public ICommand RefreshCommand
        {
            get => new RelayCommand(LoadLands);
        }

        public ICommand SearchCommand
        {
            get => new RelayCommand(Search);
        }

        

        #endregion

        #region Methods
        private async void LoadLands()
        {
            IsRefreshing = true;

            var connection = await apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                IsRefreshing = false;

                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");

                //aqui regreso al login page por si hay algun error de conneción con internet
                await Application.Current.MainPage.Navigation.PopAsync();

                return;
            }

            var response = await apiService.GetList<Land>("http://restcountries.eu", "/rest", "/v2/all");

            if (!response.IsSuccess)
            {
                IsRefreshing = false;

                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");

                //aqui regreeso al longin page si hay algún error con el consumo de datos desde la api...
                await Application.Current.MainPage.Navigation.PopAsync();

                return;
            }

            MainViewModel.GetInstance().LandList = (List<Land>)response.Result;

            this.Lands = new ObservableCollection<LandItemViewModel>(this.ToLandItemViewModel());

            IsRefreshing = false;
        }

        private IEnumerable<LandItemViewModel> ToLandItemViewModel()
        {
            return MainViewModel.GetInstance().LandList.Select(l => new LandItemViewModel {

                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings = l.AltSpellings,
                Area = l.Area,
                Borders = l.Borders,
                CallingCodes = l.CallingCodes,
                Capital = l.Capital,
                Cioc = l.Cioc,
                Currencies = l.Currencies,
                Demonym = l.Demonym,
                Flag = l.Flag,
                Gini = l.Gini,
                Languages = l.Languages,
                Latlng = l.Latlng,
                Name = l.Name,
                NativeName = l.NativeName,
                NumericCode = l.NumericCode,
                Population = l.Population,
                Region = l.Region,
                RegionalBlocs = l.RegionalBlocs,
                Subregion = l.Subregion,
                Timezones = l.Timezones,
                TopLevelDomain = l.TopLevelDomain,
                Translations = l.Translations,
                


            });  
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(Filter))
            {
                Lands = new ObservableCollection<LandItemViewModel>(ToLandItemViewModel());
            }
            else
            {
                Lands = new ObservableCollection<LandItemViewModel>(ToLandItemViewModel().Where(
                    l => l.Name.ToLower().Contains(Filter.ToLower()) 
                      ||
                   l.Capital.ToLower().Contains(Filter.ToLower())   
                ));

            }
        }

        #endregion
    }
}
