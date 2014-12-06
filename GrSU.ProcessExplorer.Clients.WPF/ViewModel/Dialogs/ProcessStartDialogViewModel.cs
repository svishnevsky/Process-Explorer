using System.Windows.Input;
using GrSU.ProcessExplorer.Clients.WPF.ViewModel.Common;
using GrSU.ProcessExplorer.Model;
using GrSU.ProcessExplorer.Clients.WPF.Messages;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace GrSU.ProcessExplorer.Clients.WPF.ViewModel.Dialogs
{
    public class ProcessStartDialogViewModel : BaseViewModel
    {
        private Process process;

        public Process Process
        {
            get { return this.process; }
            set
            {
                if (value == this.process)
                {
                    return;
                }
                this.process = value;
                base.RaisePropertyChanged("Process");
            }
        }

        public StartedProcessAction Action { get; private set; }

        public ICommand KeepRunning { get; private set; }

        public ICommand Terminate { get; private set; }

        public ProcessStartDialogViewModel()
        {
            this.KeepRunning = new RelayCommand(() => this.Action = StartedProcessAction.KeepExecute);
            this.Terminate = new RelayCommand(() => this.Action = StartedProcessAction.Kill);
        }
    }
}
