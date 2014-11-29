using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GrSU.ProcessExplorer.Clients.WPF.Dialogs;
using GrSU.ProcessExplorer.Clients.WPF.Messages;
using GrSU.ProcessExplorer.Clients.WPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GrSU.ProcessExplorer.Clients.WPF
{
    public class DialogManager
    {
        public DialogManager()
        {
            SimpleIoc.Default.Register<ProcessStartDialog>();
            Messenger.Default.Register<ProcessStartMessage>(this, ProcessStart);
        }

        public void ProcessStart(ProcessStartMessage msg)
        {
            var dialog = (ProcessStartDialog)SimpleIoc.Default.GetService(typeof(ProcessStartDialog));
            dialog.ShowDialog();
        }
    }
}
