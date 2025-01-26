using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace Todo.Visual.Pediatrico
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormularioPediatrico : Page
    {
        public FormularioPediatrico()
        {
            this.InitializeComponent();
        }
        // Método para el evento Click del botón "Confirmar"
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para procesar los datos cuando se hace clic en el botón "Confirmar"
            // Aquí puedes validar los campos o enviar los datos

            // Ejemplo simple de mensaje de confirmación
            var messageDialog = new Windows.UI.Popups.MessageDialog("¡Formulario confirmado!");
            messageDialog.ShowAsync();
        }
    }
}
