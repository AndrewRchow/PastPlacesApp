using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PastPlacesApp
{
    public partial class App : Application
    {
        public static string DbLocation = string.Empty;

        public static string DatabaseLocation { get; internal set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        public App(string dbLocation)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());

            DbLocation = dbLocation;
        }

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
    }
}
