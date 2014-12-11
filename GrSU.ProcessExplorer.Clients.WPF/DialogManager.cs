using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GrSU.ProcessExplorer.Clients.WPF.Messages;
using GrSU.ProcessExplorer.Clients.WPF.View.Dialogs;
using GrSU.ProcessExplorer.Clients.WPF.ViewModel.Dialogs;

namespace GrSU.ProcessExplorer.Clients.WPF
{
    public class DialogManager
    {
        public DialogManager()
        {
            Messenger.Default.Register<ProcessStartMessage>(this, ProcessStart);
        }

        private void ProcessStart(ProcessStartMessage msg)
        {
            var dialog = new ProcessStartDialog();
            var dataContext = (ProcessStartDialogViewModel)dialog.DataContext;
            dataContext.Process = msg.Process;
            dialog.ShowDialog();
            var action = dataContext.Action;
            dialog.Dispose();
            dialog = null;
            msg.Callback(msg.Process, action);
        }
    }
}
