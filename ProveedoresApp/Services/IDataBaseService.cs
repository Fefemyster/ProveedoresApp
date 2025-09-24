using ProveedoresApp.Models;

namespace ProveedoresApp.Services
{
    public interface IDataBaseService
    {

        public Task<List<Proveedor>> GetAllProveedores(); //Obtener todos los proveedores
        public Task<int> CreateProveedor (Proveedor proveedor); //Crear un nuevo proveedor
        public Task<int> UpdateProveedor (Proveedor proveedor); //Actualizar un proveedor existente
        public Task<int> DeleteProveedor (int id); //Eliminar un proveedor por su Id

    }
}
