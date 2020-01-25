using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CRUDXamarinFormSysne.Objetos;
using SQLite;

namespace CRUDXamarinFormSysne
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerAuto : ContentPage
    {
        Autos AutoSeleccionado;
        CRUD_SQLite db;

        public VerAuto(Autos a)
        {
            InitializeComponent();
            AutoSeleccionado = a;
            //Id.Text = a.id_auto.ToString();
            Matricula.Text = a.Matricula;
            tipoAuto.SelectedItem = a.tipo_auto;
            NombreConductor.Text = a.nombre_conductor;
            string dbFile = "auDB.db3";
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var dbPath = System.IO.Path.Combine(docPath, dbFile);
            db = new CRUD_SQLite(dbPath);
            this.DisplayAlert("Advertencia!", "Verifique que al actualizar los datos sean correctos", "OK");
        }

        private async void btnModificar_Clicked(object sender, EventArgs e)
        {
            bool flag = true;
            Autos am = new Autos();
            am = AutoSeleccionado;
            if (String.IsNullOrWhiteSpace(Matricula.Text))
            {
                flag = false;
            }
            else { am.Matricula = Matricula.Text; }

            if (tipoAuto.SelectedItem == null)
            {
                flag = false;
            }
            else { am.tipo_auto = tipoAuto.SelectedItem.ToString(); }

            if (String.IsNullOrWhiteSpace(NombreConductor.Text))
            {
                flag = false;
            }
            else { am.nombre_conductor = NombreConductor.Text; }

            if (flag)
            {
                db.Update(am);
                await Navigation.PopAsync();
            }
            else {
                await this.DisplayAlert("Advertencia", "Se ha seleccionado", "OK");
            }
            
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            bool respuesta = await DisplayAlert("Confirmación", "¿Desea eliminar este registro?", "SI", "NO");

            if (respuesta)
            {
                db.DeleteAutos(AutoSeleccionado);
                Navigation.PopAsync();
            }
            
        }
    }
}