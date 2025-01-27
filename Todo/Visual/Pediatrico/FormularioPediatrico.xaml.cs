using System;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Todo.Visual.Pediatrico
{
    public sealed partial class FormularioPediatrico : Page
    {
        public FormularioPediatrico()
        {
            this.InitializeComponent();
        }

        // Método para el evento Click del botón "Confirmar"
        private async void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            ReiniciarEstilos();

            // Validar campos obligatorios
            bool hayErrores = false;

            if (string.IsNullOrEmpty(NombreTextBox.Text))
            {
                ResaltarCampoVacio(NombreTextBox, NombreErrorText);
                hayErrores = true;
            }

            if (string.IsNullOrEmpty(ApellidosTextBox.Text))
            {
                ResaltarCampoVacio(ApellidosTextBox, ApellidosErrorText);
                hayErrores = true;
            }

            if (string.IsNullOrEmpty(EdadTextBox.Text))
            {
                ResaltarCampoVacio(EdadTextBox, EdadErrorText);
                hayErrores = true;
            }

            if (FechaNacimientoDatePicker.Date == null)
            {
                ResaltarCampoVacio(FechaNacimientoDatePicker, FechaNacimientoErrorText);
                hayErrores = true;
            }

            if (GeneroComboBox.SelectedItem == null)
            {
                ResaltarCampoVacio(GeneroComboBox, GeneroErrorText);
                hayErrores = true;
            }

            if (string.IsNullOrEmpty(CedulaTextBox.Text))
            {
                ResaltarCampoVacio(CedulaTextBox, CedulaErrorText);
                hayErrores = true;
            }

            // Detener si hay errores
            if (hayErrores)
            {
                await MostrarMensajeError("Por favor, completa los campos obligatorios.");
                return;
            }

            // Procesar los datos
            string nombre = NombreTextBox.Text;
            string apellidos = ApellidosTextBox.Text;
            string edad = EdadTextBox.Text;
            DateTime fechaNacimiento = FechaNacimientoDatePicker.Date.DateTime;
            string genero = (GeneroComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string cedula = CedulaTextBox.Text;

            // Guardar los datos
            await MostrarMensaje("Datos guardados correctamente.");
        }

        // Reiniciar los estilos de los campos
        private void ReiniciarEstilos()
        {
            UpdateBorderAppearance(NombreTextBox, false);
            UpdateBorderAppearance(ApellidosTextBox, false);
            UpdateBorderAppearance(EdadTextBox, false);
            UpdateBorderAppearance(FechaNacimientoDatePicker, false);
            UpdateBorderAppearance(GeneroComboBox, false);
            UpdateBorderAppearance(CedulaTextBox, false);

            NombreErrorText.Visibility = Visibility.Collapsed;
            ApellidosErrorText.Visibility = Visibility.Collapsed;
            EdadErrorText.Visibility = Visibility.Collapsed;
            FechaNacimientoErrorText.Visibility = Visibility.Collapsed;
            GeneroErrorText.Visibility = Visibility.Collapsed;
            CedulaErrorText.Visibility = Visibility.Collapsed;
        }

        // Resaltar un campo vacío
        private void ResaltarCampoVacio(Control control, TextBlock errorText)
        {
            UpdateBorderAppearance(control, true);
            errorText.Visibility = Visibility.Visible;
        }

        // Actualizar el borde de un control
        private void UpdateBorderAppearance(Control control, bool isInvalid)
        {
            control.BorderBrush = new SolidColorBrush(isInvalid ? Colors.Red : Colors.Gray);
            control.BorderThickness = new Thickness(isInvalid ? 2 : 1);
        }

        // Mostrar mensaje de error
        private async Task MostrarMensajeError(string mensaje)
        {
            var dialog = new MessageDialog(mensaje, "Error");
            await dialog.ShowAsync();
        }

        // Mostrar mensaje de éxito
        private async Task MostrarMensaje(string mensaje)
        {
            var dialog = new MessageDialog(mensaje, "Éxito");
            await dialog.ShowAsync();
        }
    }
}
