using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Lands
{
    using Lands.Views;
    using Xamarin.Forms;
    public partial class App : Application
	{
        #region Properties
        public static NavigationPage Navigator { get; internal set; } 
        #endregion

        #region Contructors
        public App()
        {
            InitializeComponent();

            MainPage = new MasterPage();
            //MainPage = new NavigationPage(new LoginPage());
        }
        #endregion

        #region Methods
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        } 
        #endregion
    }
}
