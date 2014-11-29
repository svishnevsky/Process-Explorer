using System.Windows.Input;
using GrSU.ProcessExplorer.Clients.WPF.ViewModel.Common;

namespace GrSU.ProcessExplorer.Clients.WPF.ViewModel.Dialogs
{
    public class ProcessStartDialogViewModel : BaseViewModel
    {
        public ICommand KeepRunning { get; private set; }

        public ICommand Terminate { get; private set; }

        public ProcessStartDialogViewModel()
        {
            
        }
    }
}
