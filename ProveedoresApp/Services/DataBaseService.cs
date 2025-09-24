
using ProveedoresApp.Models;
using SQLite;

namespace ProveedoresApp.Services
{
    public class DataBaseService : IDataBaseService
    {
        private SQLiteAsyncConnection _db;

        public DataBaseService() 
        {
            if (_db != null) return;
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Productos.db3");
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Proveedor>();

        }

        public Task<int> CreateProveedor(Proveedor proveedor)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteProveedor(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Proveedor>> GetAllProveedores()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateProveedor(Proveedor proveedor)
        {
            throw new NotImplementedException();
        }
    }
}
