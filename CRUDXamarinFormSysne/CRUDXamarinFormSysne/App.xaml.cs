using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDXamarinFormSysne
{
    public partial class App : Application
    {
            //InitializeComponent();
            public static CRUD_SQLite DB;

        public App()
        {
            string dbFile = "SongsDB.db3";


        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        var dbPath = System.IO.Path.Combine(docPath, dbFile);
            MainPage = new NavigationPage(new MainPage()) ;
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
