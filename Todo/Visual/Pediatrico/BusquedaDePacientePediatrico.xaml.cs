using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Todo.Visual.Deporte;
using Todo.Visual.Plantillas;
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
    public sealed partial class BusquedaDePacientePediatrico : Page
    {
        private ObservableCollection<PacienteViewModel> resultados;

        public BusquedaDePacientePediatrico()
        {
            this.InitializeComponent();
            resultados = new ObservableCollection<PacienteViewModel>();
            ResultadosItemsControl.ItemsSource = resultados;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            // Simular búsqueda
            resultados.Clear();

            // Aquí agregarías la lógica real de búsqueda
            // Este es solo un ejemplo
            if (!string.IsNullOrEmpty(ApellidoTextBox.Text) || !string.IsNullOrEmpty(CedulaTextBox.Text))
            {
                // Ejemplo de resultados
                resultados.Add(new PacienteViewModel
                {
                    NombreCompleto = "Juan Pérez Llugcha",
                    Cedula = "1234567890",
                    UltimaVisita = "Última visita: 15/01/2025",
                    Initial = "JP"
                });

                resultados.Add(new PacienteViewModel
                {
                    NombreCompleto = "María Pérez Martinez",
                    Cedula = "0987654321",
                    UltimaVisita = "Última visita: 20/01/2025",
                    Initial = "MP"
                });
            }
        }

        private void IngresarButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            PacienteViewModel paciente = button.DataContext as PacienteViewModel;

            if (paciente != null)
            {
                Frame.Navigate(typeof(FormularioPediatrico),paciente);
                // Aquí implementas la navegación a la ficha del paciente
                 Frame.Navigate(typeof(Formulario), paciente);
            }
        }
    }


}
