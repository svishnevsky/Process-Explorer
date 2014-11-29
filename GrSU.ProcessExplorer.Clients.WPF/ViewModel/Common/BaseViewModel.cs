using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
