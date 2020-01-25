using System;
using System.Collections.Generic;
using System.Text;
using CRUDXamarinFormSysne.Objetos;
using SQLite;

namespace CRUDXamarinFormSysne
{
    public class CRUD_SQLite : SQLiteConnection
    {
        public CRUD_SQLite(string path) : base(path)
        {
            Initialize();
        }

        void Initialize()
        {
            CreateTable<Autos>();
        }

        public List<Autos> GetAutos()
        {
            return Table<Autos>().ToList();
        }

        public Autos GetAuto(int id)
        {
            return Table<Autos>().Where(t => t.id_auto == id).First();
        }

        public bool AddAuto(Autos auto)
        {
            Insert(auto);
            return true;
        }

        public bool UpdateAutos(Autos auto)
        {
            Update(auto);
            return true;
        }

        public void DeleteAutos(Autos auto)
        {
            Delete(auto);
        }
    }
}
