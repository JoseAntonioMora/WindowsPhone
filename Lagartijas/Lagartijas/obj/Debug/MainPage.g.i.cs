﻿#pragma checksum "C:\Users\Antonio\Documents\Visual Studio 2012\Projects\WindowsPhone\Lagartijas\Lagartijas\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "89B6268A60897AB30E33E4C4944899EC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.18051
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Lagartijas {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Button btnStart;
        
        internal System.Windows.Controls.Button btnStop;
        
        internal System.Windows.Controls.TextBlock txtBlockNumero;
        
        internal System.Windows.Controls.TextBlock txtBlockTime;
        
        internal System.Windows.Controls.TextBlock txtBlockY;
        
        internal System.Windows.Controls.TextBlock txtBlockZ;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Lagartijas;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.btnStart = ((System.Windows.Controls.Button)(this.FindName("btnStart")));
            this.btnStop = ((System.Windows.Controls.Button)(this.FindName("btnStop")));
            this.txtBlockNumero = ((System.Windows.Controls.TextBlock)(this.FindName("txtBlockNumero")));
            this.txtBlockTime = ((System.Windows.Controls.TextBlock)(this.FindName("txtBlockTime")));
            this.txtBlockY = ((System.Windows.Controls.TextBlock)(this.FindName("txtBlockY")));
            this.txtBlockZ = ((System.Windows.Controls.TextBlock)(this.FindName("txtBlockZ")));
        }
    }
}

