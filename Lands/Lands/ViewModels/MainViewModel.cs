using Lands.Helpers;
using Lands.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Lands.ViewModels
{
    public class MainViewModel
    {
        #region ViewModels

        public LoginViewModel Login { get; set; }
        public LandsViewModel Lands { get; set; }
        public LandViewModel Land { get; set; }

        #endregion

        #region Properties

        public string TokenId { get; set; }
        public string TokenTypeId { get; set; }

        public ObservableCollection <MenuItemViewModel> Menus { get; set; }

        public List<Land> LandList { get; set; }

        public TokenResponse Token { get; set; }

        #endregion

        #region Constructor
        public MainViewModel()
        {
            instance = this;

            Login = new LoginViewModel();

            this.LoadMenu();
           
        }         
        #endregion

        #region Singleton

        static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }

        #endregion

        #region Methods

        private void LoadMenu()
        {
            Menus = new ObservableCollection<MenuItemViewModel>();

            Menus.Add(new MenuItemViewModel {

                Icon = "ic_settings",
                PageName ="MyProfilePage",
                Title =Languages.MyProfile,

            });

            Menus.Add(new MenuItemViewModel
            {

                Icon = "ic_insert_chart",
                PageName = "StatisticsPage",
                Title = Languages.Statistics,

            });

            Menus.Add(new MenuItemViewModel
            {

                Icon = "ic_exit_to_app",
                PageName = "LoginPage",
                Title = Languages.LogOut,

            });
        }

        #endregion
    }
}
