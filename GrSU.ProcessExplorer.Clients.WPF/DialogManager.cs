using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GrSU.ProcessExplorer.Clients.WPF.Messages;
using GrSU.ProcessExplorer.Clients.WPF.View.Dialogs;

namespace GrSU.ProcessExplorer.Clients.WPF
{
    public class DialogManager
    {
        protected readonly Dictionary<Type, Queue<MessageBase>> MessageQueue;

        public DialogManager()
        {
            SimpleIoc.Default.Register<ProcessStartDialog>();
            this.MessageQueue = new Dictionary<Type, Queue<MessageBase>>();
            Messenger.Default.Register<ProcessStartMessage>(this, ProcessStart);
            this.MessageQueue.Add(typeof(ProcessStartMessage), new Queue<MessageBase>());
        }

        private void ProcessStart(ProcessStartMessage msg)
        {
            this.MessageQueue[typeof(ProcessStartMessage)].Enqueue(msg);
            var dialog = (ProcessStartDialog)SimpleIoc.Default.GetService(typeof(ProcessStartDialog));
            dialog.ShowDialog(msg.Process);
        }
    }
}
