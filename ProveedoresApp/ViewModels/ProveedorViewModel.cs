using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProveedoresApp.Models;
using ProveedoresApp.Services;
using System.Collections.ObjectModel;

namespace ProveedoresApp.ViewModels
{
    public partial class ProveedorViewModel : ObservableObject
    {

        private DataBaseService _dbService;


        [ObservableProperty]

        private Proveedor _proveedorSeleccionado;

        [ObservableProperty]
        private ObservableCollection<Proveedor> _proveedoresCollection;

        

        public ProveedorViewModel()
        {
            _dbService = new DataBaseService();
            ProveedoresCollection = new ObservableCollection<Proveedor>();
            LoadProveedoresCommand.ExecuteAsync(null);
            ProveedorSeleccionado = new Proveedor();
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
            try
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
            catch(Exception ex)
            {
                // Manejo de errores (puedes mostrar un mensaje al usuario, etc.)
                Alerta($"Ha ocurrido un error: {ex.Message}");
            }
            

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

        private void Alerta(string mensaje)
        {
            Application.Current!.MainPage!.DisplayAlert("", mensaje, "Aceptar");
        }

    }
}
