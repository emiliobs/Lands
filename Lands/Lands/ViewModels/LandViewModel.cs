using Lands.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Lands.ViewModels
{
    public class LandViewModel  : BaseViewModel
    {

        #region Atributtes    
        ObservableCollection<Border> borders;
        ObservableCollection<Currency> currencies;
        ObservableCollection<Language> languages;
        #endregion

        #region Properties   
        public Land Land { get; set; }

        public ObservableCollection<Language> Languages
        {
            get => languages;
            set
            {
                if (languages != value)
                {
                    languages = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Border> Borders
        {
            get => borders;
            set
            {
                if (borders != value)
                {
                    borders = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<Currency> Currencies
        {
            get => currencies;
            set
            {
                if (currencies != value)
                {
                    currencies = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion


        #region Constructor
        public LandViewModel(Land land)
        {
            this.Land = land;  
            this.LoadBorders();
            Currencies = new ObservableCollection<Currency>(Land.Currencies);
            Languages = new ObservableCollection<Language>(Land.Languages);
        }

        #endregion

        #region Methods

        private void LoadBorders()
        {
            Borders = new ObservableCollection<Border>();

            foreach (var boder in this.Land.Borders)
            {
                var land = MainViewModel.GetInstance().LandList.Where(l => l.Alpha3Code == boder).FirstOrDefault();

                if (land != null)
                {
                    this.Borders.Add(new Border
                    {
                        Code = land.Alpha3Code,
                        Name = land.Name,
                    });
                }
            }
        }

        #endregion
    }
}
