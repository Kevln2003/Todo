using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
        private ObservableCollection<Usuario> usuarios;

        public AdministracionDeUsuarios()
        {
            this.InitializeComponent();
            usuarios = new ObservableCollection<Usuario>();
            CargarUsuarios();
            UsuariosListView.ItemsSource = usuarios;
        }

        private void CargarUsuarios()
        {
            // Aquí cargarías los usuarios desde tu base de datos
            // Este es solo un ejemplo
            usuarios.Add(new Usuario
            {
                NombreCompleto = "Juan Pérez",
                Usuarios = "jperez",
                Area = "Pediatría",
                Estado = "Activo",
                Iniciales = "JP",
                EstadoColor = new SolidColorBrush(Colors.Green)
            });
        }

        private void AgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            PopupTitle.Text = "Agregar Usuario";
            LimpiarFormulario();
            UserPopup.IsOpen = true;
        }

        private void EditarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Usuario usuario = button.DataContext as Usuario;
            if (usuario != null)
            {
                PopupTitle.Text = "Editar Usuario";
                CargarDatosUsuario(usuario);
                UserPopup.IsOpen = true;
            }
        }

        private void EliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Usuario usuario = button.DataContext as Usuario;
            if (usuario != null)
            {
                // Implementar confirmación y eliminación
            }
        }

        private void CambiarContrasena_Click(object sender, RoutedEventArgs e)
        {
            PasswordPopup.IsOpen = true;
        }

        private void GuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            // Implementar guardado
            UserPopup.IsOpen = false;
        }

        private void GuardarContrasena_Click(object sender, RoutedEventArgs e)
        {
            // Implementar cambio de contraseña
            PasswordPopup.IsOpen = false;
        }

        private void CancelarPopup_Click(object sender, RoutedEventArgs e)
        {
            UserPopup.IsOpen = false;
        }

        private void CancelarCambioContrasena_Click(object sender, RoutedEventArgs e)
        {
            PasswordPopup.IsOpen = false;
        }

        private void LimpiarFormulario()
        {
            NombreTextBox.Text = string.Empty;
            UsuarioTextBox.Text = string.Empty;
            ContrasenaBox.Password = string.Empty;
            AreaComboBox.SelectedIndex = -1;
        }

        private void CargarDatosUsuario(Usuario usuario)
        {
            NombreTextBox.Text = usuario.NombreCompleto;
            UsuarioTextBox.Text = usuario.Usuarios;
            AreaComboBox.SelectedItem = usuario.Area;
        }
    }

    public class Usuario
    {
        public string NombreCompleto { get; set; }
        public string Usuarios { get; set; }
        public string Area { get; set; }
        public string Estado { get; set; }
        public string Iniciales { get; set; }
        public SolidColorBrush EstadoColor { get; set; }
    }
}
