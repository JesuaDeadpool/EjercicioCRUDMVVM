using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Model
{
    public class Proveedor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string NombreProveedor { get; set; }
        public string Fabrica { get; set; }
        public int Telefono { get; set; }
        public string Producto { get; set; }
    }
}
