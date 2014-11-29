using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GrSU.ProcessExplorer.Clients.WPF.Helpers
{
    public static class DispatcherHelpers
    {
        public static void Invoke(Action action)
        {
            if (Application.Current == null || Application.Current.Dispatcher.CheckAccess())
            {
                action();
                return;
            }
            
            Application.Current.Dispatcher.InvokeAsync(() => action());
        }
    }
}
