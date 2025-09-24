
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

        public async Task<int> CreateProveedor(Proveedor proveedor)
        {
            return await _db.InsertAsync(proveedor);
        }

        public async Task<int> DeleteProveedor(int id)
        {
            return await _db.DeleteAsync<Proveedor>(id);
        }

        public async Task<List<Proveedor>> GetAllProveedores()
        {
            return await _db.Table<Proveedor>().ToListAsync();
        }

        public async Task<int> UpdateProveedor(Proveedor proveedor)
        {
            return await _db.UpdateAsync(proveedor);
        }
    }
}
