

using SQLite;

namespace ProveedoresApp.Models
{
    [Table("Proveedores")] //Definimos el nombre de la tabla en la base de datos
    public class Proveedor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Nombre { get; set; }
        [NotNull]
        public string Direccion { get; set; }
        [NotNull]
        public string Telefono { get; set; }
        [NotNull]
        public string Email { get; set; }

    }
}
