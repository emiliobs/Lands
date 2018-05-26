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

        #endregion

        #region Properties   
        public Land Land { get; set; }

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

        #endregion


        #region Constructor
        public LandViewModel(Land land)
        {
            this.Land = land;  
            this.LoadBorders();
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
