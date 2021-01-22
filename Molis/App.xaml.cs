using System;
using Molis.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



[assembly: ExportFont("Quicksand-Bold.ttf", Alias = "BrandBold")]
[assembly: ExportFont("Quicksand-Light.ttf", Alias = "BrandLight")]
[assembly: ExportFont("Quicksand-Medium.ttf", Alias = "BrandMedium")]
[assembly: ExportFont("Quicksand-SemiBold.ttf", Alias = "BrandSemiBold")]


namespace Molis
{
    public partial class App : Application
    {

        static PrayerItemDatabase database;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#262730"),
                BarTextColor = Color.White
            };
        }


        public static PrayerItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new PrayerItemDatabase();
                }
                return database;
            }
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
