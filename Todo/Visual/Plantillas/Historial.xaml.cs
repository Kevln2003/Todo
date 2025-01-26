using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Todo.Visual.Deporte;
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

namespace Todo.Visual.Plantillas
{
    public sealed partial class Historial : Page
    {
        private ObservableCollection<PacienteViewModel> resultados;

        public Historial()
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
                    NombreCompleto = "Juan Pérez González",
                    Cedula = "1234567890",
                    UltimaVisita = "Última visita: 15/01/2025",
                    Initial = "JP"
                });
                resultados.Add(new PacienteViewModel
                {
                    NombreCompleto = "María Pérez Rodríguez",
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
                // Navegación al formulario
                this.Frame.Navigate(typeof(Formulario), paciente);
            }
        }
    }

    public class PacienteViewModel
    {
        public string NombreCompleto { get; set; }
        public string Cedula { get; set; }
        public string UltimaVisita { get; set; }
        public string Initial { get; set; }
    }
}