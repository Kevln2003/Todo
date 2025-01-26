using Todo.Logica;
using Todo.Visual.Administrativo;
using Todo.Visual.Deporte;
using Todo.Visual.Pediatrico;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Todo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Usuario usuario = new Usuario(1, "Juan Pérez", "juan.perez@example.com", "contraseña123", "Medicina Deportiva");
        Usuario usuario2 = new Usuario(1, "Maria Jose", "Maria.perez@example.com", "contraseña1234", "Pediatría");
        //Admin
        Usuario usuario3 = new Usuario(1, "Maria Jose", "Maria.3@example.com", "contraseña", "Administración");
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string especialidadSeleccionada = (EspecialidadComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string usuarioIngreso = UsuarioTextBox.Text;
            string contrasena = ContrasenaPasswordBox.Password;

            // Validación de credenciales según la especialidad seleccionada
            if (string.IsNullOrEmpty(especialidadSeleccionada))
            {
                MostrarMensajeError("Por favor seleccione una especialidad.");
                return;
            }

            if (usuario.ValidarCredenciales(usuarioIngreso, contrasena, especialidadSeleccionada) && especialidadSeleccionada == "Medicina Deportiva")
            {
                Usuario medicoDeportivo = new Usuario(usuario.Id, usuario.Nombre, usuario.Email, usuario.Contraseña, usuario.Tipo);
                Frame.Navigate(typeof(MedicinaDeportiva), medicoDeportivo);
            }
            else if (usuario2.ValidarCredenciales(usuarioIngreso, contrasena, especialidadSeleccionada) && especialidadSeleccionada == "Pediatría")
            {
                Usuario pediatricoUsuario = new Usuario(usuario2.Id, usuario2.Nombre, usuario2.Email, usuario2.Contraseña, usuario2.Tipo);
                Frame.Navigate(typeof(Pediatria), pediatricoUsuario);
            }
            else if (usuario3.ValidarCredenciales(usuarioIngreso, contrasena, especialidadSeleccionada) && especialidadSeleccionada == "Administración")
            {
                Usuario administrativoUsuario = new Usuario(usuario3.Id, usuario3.Nombre, usuario3.Email, usuario3.Contraseña, usuario3.Tipo);
                Frame.Navigate(typeof(AdminTracion), administrativoUsuario);
            }
            else
            {
                MostrarMensajeError("Usuario o contraseña incorrectos.");
            }
        }

        private void MostrarMensajeError(string mensaje)
        {
            var dialog = new ContentDialog
            {
                Title = "Error de inicio de sesión",
                Content = mensaje,
                CloseButtonText = "Aceptar"
            };
            dialog.ShowAsync();
        }
        private void Control_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            // Verifica si la tecla presionada es Enter
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                // Encuentra el siguiente elemento en el orden de tabulación
                var control = sender as Control;
                control?.Focus(FocusState.Keyboard);

                var next = FocusManager.FindNextFocusableElement(FocusNavigationDirection.Next) as Control;
                next?.Focus(FocusState.Keyboard);
            }
        }

    }
}
