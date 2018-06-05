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

        public static string YouEnterPassword { get=>Resource.YouEnterPassword; }
        public static string MyProfile { get => Resource.MyProfile; }
        public static string Statistics { get => Resource.Statistics; }
        public static string LogOut { get => Resource.LogOut; }
        public static string RegisterTitle { get => Resource.RegisterTitle; }
        public static string ChangeImage { get => Resource.ChangeImage; }
        public static string FirstNameLabel { get => Resource.FirstNameLabel; }
        public static string FirstNamePlaceHolder { get => Resource.FirstNamePlaceHolder; }
        public static string FirstNameValidation { get => Resource.FirstNameValidation; }
        public static string LastNameLabel { get => Resource.LastNameLabel; }
        public static string LastNamePlaceHolder { get => Resource.LastNamePlaceHolder; }
        public static string LastNameValidation { get => Resource.LastNameValidation; }
        public static string PhoneLabel { get => Resource.PhoneLabel; }
        public static string PhonePlaceHolder  { get => Resource.PhonePlaceHolder; }
        public static string PhoneValidation { get => Resource.PhoneValidation; }
        public static string ConfirmLabel { get => Resource.ConfirmLabel; }
        public static string ConfirmPlaceHolder { get => Resource.ConfirmPlaceHolder; }
        public static string ConfirmValidation { get => Resource.ConfirmValidation; }
        public static string ConfirmValidation2 { get => Resource.ConfirmValidation2; }
        public static string PasswordValidation2 { get => Resource.PasswordValidation2; }
        public static string UserRegisterMessage { get => Resource.UserRegisterMessage; }
        public static string SourceImageQuestion { get => Resource.SourceImageQuestion; }
        public static string Cancel { get => Resource.Cancel; }
        public static string FromGallery { get => Resource.FromGallery; }
        public static string FromCamera { get => Resource.FromCamera; }

        public static string Menu
        {
            get { return Resource.Menu; }
        }
        public static string Accept
        {
            get { return Resource.Accept; }
        }

        public static string EmailValidation
        {
            get { return Resource.EmailValidation; }
        }

        public static string Error
        {
            get { return Resource.Error; }
        }

        public static string EmailPlaceHolder
        {
            get { return Resource.EmailPlaceHolder; }
        }

        public static string Rememberme
        {
            get { return Resource.Rememberme; }
        }

        public static string PasswordValidation
        {
            get { return Resource.PasswordValidation; }
        }

        public static string SomethingWrong
        {
            get { return Resource.SomethingWrong; }
        }

        public static string Login
        {
            get { return Resource.Login; }
        }

        public static string EMail
        {
            get { return Resource.EMail; }
        }

        public static string Password
        {
            get { return Resource.Password; }
        }

        public static string PasswordPlaceHolder
        {
            get { return Resource.PasswordPlaceHolder; }
        }

        public static string Forgot
        {
            get { return Resource.Forgot; }
        }

        public static string Register
        {
            get { return Resource.Register; }
        }

        public static string Countries
        {
            get { return Resource.Countries; }
        }

        public static string Search
        {
            get { return Resource.Search; }
        }

        public static string Country
        {
            get { return Resource.Country; }
        }

        public static string Information
        {
            get { return Resource.Information; }
        }

        public static string Capital
        {
            get { return Resource.Capital; }
        }

        public static string Population
        {
            get { return Resource.Population; }
        }

        public static string Area
        {
            get { return Resource.Area; }
        }

        public static string AlphaCode2
        {
            get { return Resource.AlphaCode2; }
        }

        public static string AlphaCode3
        {
            get { return Resource.AlphaCode3; }
        }

        public static string Region
        {
            get { return Resource.Region; }
        }

        public static string Subregion
        {
            get { return Resource.Subregion; }
        }

        public static string Demonym
        {
            get { return Resource.Demonym; }
        }

        public static string GINI
        {
            get { return Resource.GINI; }
        }

        public static string NativeName
        {
            get { return Resource.NativeName; }
        }

        public static string NumericCode
        {
            get { return Resource.NumericCode; }
        }

        public static string CIOC
        {
            get { return Resource.CIOC; }
        }

        public static string Borders
        {
            get { return Resource.Borders; }
        }

        public static string Currencies
        {
            get { return Resource.Currencies; }
        }

        public static string MyLanguages
        {
            get { return Resource.MyLanguages; }
        }
    }
}
