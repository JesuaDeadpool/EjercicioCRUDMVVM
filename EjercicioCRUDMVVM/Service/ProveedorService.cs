using MauiApp3.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Service
{
  

   public class ProveedorService
    {

        private readonly SQLiteConnection _connection;


        public ProveedorService()
        {

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Proveedor.db3");

            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<Proveedor>();

            Proveedor proveedors = new Proveedor();
        }



        public List<Proveedor> GetAll()
        {
            return _connection.Table<Proveedor>().ToList(); 
        }

        public int Insert(Proveedor proveedor)
        {
            return _connection.Insert(proveedor); 
        }

        public int Update(Proveedor proveedor)
        {
            return _connection.Update(proveedor); 
        }

        public int Delete(Proveedor proveedor)
        {
            return _connection.Delete(proveedor);
        }
    }

}
