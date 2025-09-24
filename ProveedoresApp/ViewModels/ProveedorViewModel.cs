using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProveedoresApp.Models;
using ProveedoresApp.Services;
using System.Collections.ObjectModel;

namespace ProveedoresApp.ViewModels
{
    public partial class ProveedorViewModel : ObservableObject
    {

        private readonly IDataBaseService _dbService;


        [ObservableProperty]

        private Proveedor _proveedorSeleccionado;

        [ObservableProperty]
        private ObservableCollection<Proveedor> _proveedoresCollection;

        public ProveedorViewModel(IDataBaseService dbService)
        {
            _dbService = dbService;
            ProveedoresCollection = new ObservableCollection<Proveedor>();
            LoadProveedoresCommand.ExecuteAsync(null);
        }

        [RelayCommand]
        public async Task LoadProveedores()
        {
            var proveedores = await _dbService.GetAllProveedores();
            ProveedoresCollection.Clear();
            foreach (var proveedor in proveedores)
            {
                ProveedoresCollection.Add(proveedor);
            }
        }

        [RelayCommand]
        private async Task GuardarProveedor()
        {
            if (ProveedorSeleccionado.Id == 0)
            {
                await _dbService.CreateProveedor(ProveedorSeleccionado);
            }
            else
            {
                await _dbService.UpdateProveedor(ProveedorSeleccionado);
            }

            await LoadProveedores();
            ProveedorSeleccionado = new Proveedor(); // Limpiar el formulario

        }

        [RelayCommand]
        private void CrearNuevoProveedor()
        {
            ProveedorSeleccionado = new Proveedor();
        }

        [RelayCommand]
        private async Task EliminarProveedor()
        {
            if (ProveedorSeleccionado != null && ProveedorSeleccionado.Id != 0)
            {
                await _dbService.DeleteProveedor(ProveedorSeleccionado.Id);
                await LoadProveedores();
                ProveedorSeleccionado = new Proveedor(); // Limpiar el formulario
            }
        }
    }
}
