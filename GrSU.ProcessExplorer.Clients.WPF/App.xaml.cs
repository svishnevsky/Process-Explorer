﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Elysium;
using System.Windows.Media;
using GalaSoft.MvvmLight.Ioc;
using GrSU.ProcessExplorer.Clients.WPF.View;
using GalaSoft.MvvmLight.Messaging;
using GrSU.ProcessExplorer.Clients.WPF.Messages;
using System.Management;

namespace GrSU.ProcessExplorer.Clients.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Occured an error");
            e.Handled = true;
            //TODO: Log error
        }

        private void StartupHandler(object sender, StartupEventArgs e)
        {
            this.Apply(Theme.Light, AccentBrushes.Blue, new SolidColorBrush(Colors.White));
            SimpleIoc.Default.Register<ProcessListView>();
            SimpleIoc.Default.Register<ActivityInfoView>();
        }
    }
}