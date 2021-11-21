using System;
using System.IO;
using PM2FirmaDigitalAD.Controller;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2FirmaDigitalAD
{
    public partial class App : Application
    {
        static DataBaseSqlite dataBaseE1;

        public static DataBaseSqlite BaseDatos
        {
            get
            {
                if (dataBaseE1 == null)
                    dataBaseE1 = new DataBaseSqlite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PM2DBSQLITE.db3"));

                return dataBaseE1;
            }
        }

        public App()
        {
            InitializeComponent();
            
            MainPage = new NavigationPage(new SignUserPage());
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
