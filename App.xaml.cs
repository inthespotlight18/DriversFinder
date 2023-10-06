using System.Diagnostics;
using DriversFinder.Pages;

namespace DriversFinder
{
    public partial class App : Application
    {
        public App()
        {
            

           // MainPage = new AppShell();

            try
            {
                InitializeComponent();

               // MainPage = new NavigationPage(new Finder());
                MainPage = new NavigationPage(new DriversInfo());
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Daniil error - " + ex.Message);

            }
        }
    }
}