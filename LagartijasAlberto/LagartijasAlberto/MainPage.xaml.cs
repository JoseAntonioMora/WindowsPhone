using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using LagartijasAlberto.Resources;
using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework;

namespace LagartijasAlberto
{
    public partial class MainPage : PhoneApplicationPage
    {
        Accelerometer acelerometro;
        bool completa = false;
        int lagartijas = -1;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            if (!Accelerometer.IsSupported)
            {
                MessageBox.Show("Tu celular es chafa", "Error", MessageBoxButton.OK);
                btnInicio.IsEnabled = false;
                btnFinal.IsEnabled = false;
            }

            btnInicio.Tap += btnInicio_Tap;
            btnFinal.Tap += btnFinal_Tap;
            

            // Código de ejemplo para traducir ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        void btnFinal_Tap(object sender, System.Windows.Input.GestureEventArgs e)   
        {
            try
            {
                acelerometro.Stop();
                MessageBox.Show("Acelerometro se ha detenido correctamente", "Correcto!", MessageBoxButton.OK);
            }
            catch 
            {
                MessageBox.Show("No se ha detenido correctamente", "Error", MessageBoxButton.OK);
            }
        }

        void btnInicio_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            acelerometro = new Accelerometer();
            acelerometro.TimeBetweenUpdates = TimeSpan.FromMilliseconds(20);
            acelerometro.CurrentValueChanged+= new EventHandler<SensorReadingEventArgs<AccelerometerReading>> (acelerometro_CurrentValueChanged);
            try
            {
                acelerometro.Start();
                MessageBox.Show("Acelerometro se ha activdo! n.n", "Correcto!", MessageBoxButton.OK);
            }
            catch
            {
                MessageBox.Show("No puede activar el accelerometro, intenta mas tarde", "Advertencia",MessageBoxButton.OK);
            }
        }

        private void acelerometro_CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            Dispatcher.BeginInvoke(() => actualizadatos(e.SensorReading));
        }

        private void actualizadatos(AccelerometerReading accelerometerReading)
        {
            Vector3 aceleracion = accelerometerReading.Acceleration;
            if (aceleracion.Y >= -0.5)
            {
                completa = false;
            }
            if(aceleracion.Y <=-0.5 && completa == false)
            {
                lagartijas++;
                Numero.Text = lagartijas.ToString();
                completa = true;
            }
        }

        // Código de ejemplo para compilar una ApplicationBar traducida
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Establecer ApplicationBar de la página en una nueva instancia de ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Crear un nuevo botón y establecer el valor de texto en la cadena traducida de AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Crear un nuevo elemento de menú con la cadena traducida de AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}