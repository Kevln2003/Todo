using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Todo.Logica;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Todo.Visual.Administrativo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdministracionDeUsuarios : Page
    {
   private List<Usuario> listaUsuarios;

        public AdministracionDeUsuarios()
        {
            this.InitializeComponent();
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            listaUsuarios = new List<Usuario>
        {
             new Usuario(1, "Maria Jose", "Maria.perez@example.com", "contraseña1234", "Pediatría"),
             new Usuario(1, "Juan Pérez", "juan.perez@example.com", "contraseña123", "Medicina Deportiva")
             ///
        };

            UsuariosListView.ItemsSource = listaUsuarios;
        }

        private void CrearUsuario_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para crear un nuevo usuario
        }

        private void EliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para eliminar un usuario seleccionado
        }

        private void BloquearUsuario_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para bloquear un usuario seleccionado
        }

        private void CambiarContrasena_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para cambiar la contraseña de un usuario seleccionado
        }
    }
}

