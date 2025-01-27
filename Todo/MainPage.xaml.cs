﻿
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
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string especialidadSeleccionada = (EspecialidadComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string usuario = UsuarioTextBox.Text;
            string contrasena = ContrasenaPasswordBox.Password;

            // Validación de credenciales según la especialidad seleccionada
            if (especialidadSeleccionada == "Medicina Deportiva")
            {
                if (usuario == "Gringo" && contrasena == "2022")
                {
                    Frame.Navigate(typeof(MedicinaDeportiva));
                }
                else
                {
                    MostrarMensajeError("Usuario o contraseña incorrectos para Medicina Deportiva.");
                }
            }
            else if (especialidadSeleccionada == "Pediatría")
            {
                if (usuario == "Luna" && contrasena == "2019")
                {
                    Frame.Navigate(typeof(Pediatria));
                }
                else
                {
                    MostrarMensajeError("Usuario o contraseña incorrectos para Pediatría.");
                }
            }
            else if (especialidadSeleccionada == "Administración")
            {
                if (usuario == "Luna" && contrasena == "2019")
                {
                    Frame.Navigate(typeof(AdminTracion));
                }
                else
                {
                    MostrarMensajeError("Usuario o contraseña incorrectos para Pediatría.");
                }
            }
            else
            {
                MostrarMensajeError("Por favor seleccione una especialidad.");
            }
        }

        private void MostrarMensajeError(string mensaje)
        {
            var dialog = new ContentDialog
            {///
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

