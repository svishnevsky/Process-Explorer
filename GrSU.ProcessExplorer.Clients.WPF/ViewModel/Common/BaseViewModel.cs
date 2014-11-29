using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
using System;

namespace GrSU.ProcessExplorer.Clients.WPF.ViewModel.Common
{
    public abstract class BaseViewModel : ViewModelBase
    {
        protected void Invoke(Action action)
        {
            DispatcherHelper.RunAsync(action).Wait();
        }
    }
}
