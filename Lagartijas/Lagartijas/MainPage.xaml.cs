using Microsoft.Devices.Sensors;  // para el giroscopio
using Microsoft.Phone.Controls;
using Microsoft.Phone.Scheduler;
using Microsoft.Xna.Framework;  // para el giroscopio
using System;
using System.Windows;

namespace Lagartijas
{
    public partial class MainPage : PhoneApplicationPage
    {                
        //Contador para los milisegundos y los segudos
        int miliseg = 0;
        int segundos = 0;

        //instancio el giroscopio
        Accelerometer Acelerometro;

        //bandera para la inclinacion
        bool completa = false;

        int Abdominales = -1;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            //Verifico si existe el sensor
            if (!Accelerometer.IsSupported)
            {
                MessageBox.Show("Tu dispositivo no dispone de un acelerometro", "Atencion", MessageBoxButton.OK);
                btnStart.IsEnabled = false;
                btnStop.IsEnabled = false;
            }        

            //Agrego los eventos para cuando se toquen los botnoes
            btnStart.Tap += btnStart_Tap;
            btnStop.Tap += btnStop_Tap;

           

            // Código de ejemplo para traducir ApplicationBar
            //BuildLocalizedApplicationBar();
        }


        void btnStart_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (Acelerometro == null)
            {
                Acelerometro = new Accelerometer();
                Acelerometro.TimeBetweenUpdates = TimeSpan.FromMilliseconds(20);
                Acelerometro.CurrentValueChanged += 
                    new EventHandler<SensorReadingEventArgs<AccelerometerReading>>(Acelerometro_CurrentValueChanged);
            }
            try
            {
                Acelerometro.Start();
                MessageBox.Show("Acelerometro Activado :D", "Listo", MessageBoxButton.OK);
            }
            catch
            {
                MessageBox.Show("Ocurrio un error al activar el acelerometro, intenta más tarde", "Error", MessageBoxButton.OK);
            }
        }

        private void Acelerometro_CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            Dispatcher.BeginInvoke(() => UpdateUI(e.SensorReading));//Lo paso al hilo principal del WP
        }

        private void UpdateUI(AccelerometerReading accelerometerReading)
        {
            Vector3 aceleracion = accelerometerReading.Acceleration;
            
            //Comparo los milisegundos si es igual a 50 es igual a 1 segundo
            if (miliseg == 50)
            {
                miliseg = 0;
                segundos++;
                txtBlockTime.Text = segundos + "." + miliseg + " s";
            }
            else
            {
                //Agrego 1 a los milisegundos
                txtBlockTime.Text = segundos + "." + miliseg + " s";
                miliseg++;
            }

            //obtengo los valores de aceleromero

            txtBlockY.Text = "Y: " + aceleracion.Y.ToString("0.00");
            txtBlockZ.Text = "Z: " + aceleracion.Z.ToString("0.00");

            //Reviso para que si Y == 1 Agrege una abdominal :D
            if (aceleracion.Y >= -0.38)
            {
                completa = false;
            }

            if (aceleracion.Y <= -0.38 && completa == false)
            {
                AgregaAbdominal(1);
                completa = true;
            }                

        }

        private void AgregaAbdominal(int uno)
        {
            Abdominales = Abdominales + uno;
            txtBlockNumero.Text = Convert.ToString(Abdominales);
        }

        void btnStop_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (Acelerometro != null)
            { 
                //Dtengo al acelerometro
                Acelerometro.Stop();
                MessageBox.Show("Acelerometro Detenido :D", "Listo", MessageBoxButton.OK);
            }

            //Codigo para la alarma   Metodo Simplex
            //if (ScheduledActionService.Find("Routine") != null)
            //{
            //    Reminder r1 = ScheduledActionService.Find("Routine") as Reminder;
            //    r1.Title = "Daily Routine.";
            //    r1.Content = "Recuerda Hacer Ejercicio :D.";
            //    r1.NavigationUri = new Uri("/MainPage.xaml", UriKind.Relative);
            //    r1.BeginTime = DateTime.Now.AddSeconds(10);
            //    r1.ExpirationTime = DateTime.Now.AddDays(1);

            //    ScheduledActionService.Replace(r1);
            //}
            //else
            //{
            //    Reminder r = new Reminder("Routine");
            //    r.Title = "Daily Routine";
            //    r.Content = "Recuerda Hacer ejercicio Diario";
            //    r.NavigationUri = new Uri("/MainPage.xaml", UriKind.Relative);
            //    r.BeginTime = DateTime.Now.AddSeconds(10);
            //    r.ExpirationTime = DateTime.Now.AddDays(1);
            //    r.RecurrenceType = RecurrenceInterval.Weekly;

            //    ScheduledActionService.Add(r);
            //}

        }        
    }
}