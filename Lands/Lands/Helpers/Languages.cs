using Lands.Interfaces;
using Lands.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Lands.Helpers
{
    public class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Accept
        {
            get => Resource.Accept;

        }

        public static string EmailValidation
        {
            get => Resource.EmailValidation;

        }

        public static string Error
        {
            get => Resource.Error;

        }

        //public static string PasswordVaidator
        //{
        //    get => Resource.PasswordValidator;

        //}



        //public static string SomethingWasWrong
        //{
        //    get => Resources.SomethingWasWrong;

        //}

        //public static string Rememberme
        //{
        //    get => Resources.Rememberme;

        //}

        //public static string EmailPlaceHolder
        //{
        //    get => Resource.EmailPlaceHolder;

        //}

        //public static string PasswordPlaceHolder
        //{
        //    get => Resource.PasswordPlaceHolder;

        //}

        //public static string Menu
        //{
        //    get => Resource.Menu;

        //}

        //public static string MyProfile
        //{
        //    get => Resource.MyProfile;

        //}

        //public static string LogOut
        //{
        //    get => Resource.LogOut;
        //}

        //public static String Statistic
        //{
        //    get => Resource.Statistic;
        //}
    }
}
