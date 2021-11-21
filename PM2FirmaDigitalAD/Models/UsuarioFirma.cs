using System;
using System.IO;
using SQLite;
using Xamarin.Forms;

namespace PM2FirmaDigitalAD.Models
{
    public class UsuarioFirma
    {
        public UsuarioFirma()
        {
        }


        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public String imagen { get; set; }

        [MaxLength(70)]
        public String nombre { get; set; }
        [MaxLength(300)]
        public String descripcion { get; set; }
    }
}
