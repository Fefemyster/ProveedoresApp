using ProveedoresApp.Models;

namespace ProveedoresApp.Services
{
    public interface IDataBaseService
    {
        Task<List<Proveedor>> GetAllProveedores();
            
    }
}
