using System;
using System.IO;
using Xamarin.Forms;

namespace otAleksandrovny
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "customers.db";
        public static CustomerRepository database;
        public static CustomerRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new CustomerRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.Transparent,
                BarTextColor = Color.DimGray
            };
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
