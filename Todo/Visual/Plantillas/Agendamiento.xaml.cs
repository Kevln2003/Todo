using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Todo.Visual.Plantillas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class Agendamiento : Page
    {  private DateTime currentDate;
    private List<TimeSlotRow> timeSlots;

        public Agendamiento()
        {
            InitializeComponent();
            currentDate = DateTime.Now.Date;
            InitializeTimeSlots();
            UpdateCalendarView();
        
        }

        private void InitializeTimeSlots()
        {
            timeSlots = new List<TimeSlotRow>();
            DateTime startTime = DateTime.Today.AddHours(9); // 9 AM
            DateTime endTime = DateTime.Today.AddHours(17);  // 5 PM

            while (startTime < endTime)
            {
                timeSlots.Add(new TimeSlotRow(startTime, GetWeekDays()));
                startTime = startTime.AddHours(2); // Intervalos de 2 horas
            }

            HorariosControl.ItemsSource = timeSlots;
        }
        private List<DateTime> GetWeekDays()
        {
            // Obtener el lunes de la semana actual
            DateTime monday = currentDate.AddDays(-(int)currentDate.DayOfWeek + (int)DayOfWeek.Monday);
            var weekDays = new List<DateTime>();

            // Generar los 7 días de la semana
            for (int i = 0; i < 7; i++)
            {
                weekDays.Add(monday.AddDays(i));
            }

            return weekDays;
        }

        private int GetWeekOfMonth(DateTime date)
        {
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            return (date.Day - 1) / 7 + 1;
        }

        private void UpdateCalendarView()
        {
            var weekDays = GetWeekDays();
            MonthYearText.Text = currentDate.ToString("MMMM yyyy").ToUpper();
            WeekText.Text = $"Semana {GetWeekOfMonth(currentDate)}";

            // Actualizar los encabezados con las fechas
            Lunes.Text = $"LUNES {weekDays[0].Day}";
            Martes.Text = $"MARTES {weekDays[1].Day}";
            Miercoles.Text = $"MIÉRCOLES {weekDays[2].Day}";
            Jueves.Text = $"JUEVES {weekDays[3].Day}";
            Viernes.Text = $"VIERNES {weekDays[4].Day}";
            Sabado.Text = $"SÁBADO {weekDays[5].Day}";
            Domingo.Text = $"DOMINGO {weekDays[6].Day}";

            InitializeTimeSlots();
        }

        // Los métodos de navegación
        private void PrevMonth_Click(object sender, RoutedEventArgs e)
        {
            currentDate = currentDate.AddMonths(-1);
            UpdateCalendarView();
        }

        private void NextMonth_Click(object sender, RoutedEventArgs e)
        {
            currentDate = currentDate.AddMonths(1);
            UpdateCalendarView();
        }

        private void PrevWeek_Click(object sender, RoutedEventArgs e)
        {
            currentDate = currentDate.AddDays(-7);
            UpdateCalendarView();
        }

        private void NextWeek_Click(object sender, RoutedEventArgs e)
        {
            currentDate = currentDate.AddDays(7);
            UpdateCalendarView();
        }

        private void CitaClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            DaySlot daySlot = button.Tag as DaySlot;
            if (daySlot != null && button.IsEnabled)
            {
                FechaHoraSeleccionada.Text = $"{daySlot.Date.ToShortDateString()} {daySlot.Time.ToString("HH:mm")}";
                CitaPopup.IsOpen = true;
            }
        }
        private void CerrarPopup(object sender, RoutedEventArgs e)
        {
            CitaPopup.IsOpen = false;
            LimpiarFormulario();
        }

        private void GuardarCita(object sender, RoutedEventArgs e)
        {
            // Implementar lógica para guardar la cita
            CitaPopup.IsOpen = false;
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            NombrePacienteTextBox.Text = string.Empty;
            ObservacionesTextBox.Text = string.Empty;
        }
    }

    public class TimeSlot
    {
        public string Hora { get; set; }
        public DateTime StartTime { get; set; }
    }
    public class TimeSlotRow
    {
        public string Hora { get; set; }
        public DaySlot Monday { get; set; }
        public DaySlot Tuesday { get; set; }
        public DaySlot Wednesday { get; set; }
        public DaySlot Thursday { get; set; }
        public DaySlot Friday { get; set; }
        public DaySlot Saturday { get; set; }
        public DaySlot Sunday { get; set; }

        public TimeSlotRow(DateTime time, List<DateTime> weekDays)
        {
            Hora = time.ToString("HH:mm");

            Monday = new DaySlot(weekDays[0], time);
            Tuesday = new DaySlot(weekDays[1], time);
            Wednesday = new DaySlot(weekDays[2], time);
            Thursday = new DaySlot(weekDays[3], time);
            Friday = new DaySlot(weekDays[4], time);
            Saturday = new DaySlot(weekDays[5], time);
            Sunday = new DaySlot(weekDays[6], time);
        }
    }

    public class DaySlot
    {
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Appointments { get; set; }
        public bool IsCurrentMonth { get; set; }
        public string BackgroundColor { get; set; }
        public string ForegroundColor { get; set; }
        public bool IsEnabled { get; set; }

        public DaySlot(DateTime date, DateTime time)
        {
            Date = date;
            Time = time;
            Appointments = "";
            IsCurrentMonth = date.Month == DateTime.Now.Month;

            if (IsCurrentMonth)
            {
                BackgroundColor = "#FFFFFF";  // White
                ForegroundColor = "#000000";  // Black
                IsEnabled = true;
            }
            else
            {
                BackgroundColor = "#D3D3D3";  // Light Gray
                ForegroundColor = "#808080";  // Gray
                IsEnabled = false;
            }
        }
    }
}
