using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using CRUDXamarinFormSysne.Objetos;

namespace CRUDXamarinFormSysne
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        int index;
        CRUD_SQLite db;
        public IList<Autos> listaAutos { get; set; }

        public MainPage()
        {
            
            InitializeComponent();
            index = 0;
            string dbFile = "auDB.db3";
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var dbPath = System.IO.Path.Combine(docPath, dbFile);
            db = new CRUD_SQLite(dbPath);
            BindingContext = this;
            //VistaLista.ItemsSource = db.GetAutos();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            bool flag = true;
            Autos a = new Autos();
            a.id_auto = index + 1;
            if (String.IsNullOrWhiteSpace(matricula.Text))
            {
                flag = false;
            }
            else {
                a.Matricula = matricula.Text;
            }

            if (tipoAuto.SelectedItem == null)
            {
                flag = false;
            }
            else {
                a.tipo_auto = tipoAuto.SelectedItem.ToString();
            }

            if (String.IsNullOrWhiteSpace(NombreConductor.Text))
            {
                flag = false;
            }
            else {
                a.nombre_conductor = NombreConductor.Text;
            }


            if (flag)
            {
                db.AddAuto(a);
                VistaLista.ItemsSource = db.GetAutos();
                matricula.Text = "";
                tipoAuto.SelectedItem = null;
                NombreConductor.Text = "";
            }
            else {
                this.DisplayAlert("Advertencia", "Verifique que los campos esten correctos", "OK");
            }

        }

        private void ver_Clicked(object sender, EventArgs e)
        {
            VistaLista.ItemsSource = db.GetAutos();
        }


        async void VistaLista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            Autos SelectedAuto = e.SelectedItem as Autos;
            await Navigation.PushAsync(new VerAuto(SelectedAuto));
            VistaLista.ItemsSource = db.GetAutos();
        }

        private void VistaLista_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}
