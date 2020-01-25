using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CRUDXamarinFormSysne.Objetos
{
    [Table("Autos")]
    public class Autos
    {
        [PrimaryKey][AutoIncrement]
        public int id_auto { get; set; }
        public string Matricula { get; set; }
        public string tipo_auto { get; set; }
        public string nombre_conductor { get; set; }
       
        public string AutotoString() {
            return id_auto + ".- " + Matricula + ", " + tipo_auto + ", " + nombre_conductor; 
        }
        
    }
}
