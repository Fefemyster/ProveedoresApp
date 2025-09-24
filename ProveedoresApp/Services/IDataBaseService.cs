using ProveedoresApp.Models;

namespace ProveedoresApp.Services
{
    public interface IDataBaseService
    {

        Task<List<Proveedor>> GetAllProveedores(); //Obtener todos los proveedores
        Task<int> CreateProveedor (Proveedor proveedor); //Crear un nuevo proveedor
        Task<int> UpdateProveedor (Proveedor proveedor); //Actualizar un proveedor existente
        Task<int> DeleteProveedor (int id); //Eliminar un proveedor por su Id

    }
}
