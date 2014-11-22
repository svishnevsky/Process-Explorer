using GalaSoft.MvvmLight;
using GrSU.ProcessExplorer.Clients.WPF.Messages;
using GrSU.ProcessExplorer.Clients.WPF.Mapping;
using GrSU.ProcessExplorer.Clients.WPF.Model.ProcessList;
using GrSU.ProcessExplorer.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using GrSU.ProcessExplorer.Clients.WPF.ViewModel.Common;

namespace GrSU.ProcessExplorer.Clients.WPF.ViewModel
{
    public class ProcessListViewModel : BaseViewModel
    {
        private IProcessManager processManager;

        public ObservableCollection<ProcessListItem> ProcessList { get; set; }

        public ProcessListViewModel(IProcessManager processManager)
        {
            this.processManager = processManager;
            this.ProcessList = new ObservableCollection<ProcessListItem>();
            MessengerInstance.Register<LoadProcessListMessage>(this, OnLoadProcessList);
        }

        private void OnLoadProcessList(LoadProcessListMessage msg)
        {
            using (var worker = new BackgroundWorker())
            {
                worker.DoWork += (sender, args) =>
                    {
                        base.MessengerInstance.Send(new StartWorkMessage());
                        var processList = this.processManager
                            .GetProcesses()
                            .Select(item => item.Map<ProcessListItem>());
                        args.Result = processList;
                    };

                worker.RunWorkerCompleted += (sender, args) =>
                    {
                        this.ProcessList.Clear();
                        var processList = (IEnumerable<ProcessListItem>)args.Result;
                        foreach (var process in processList)
                        {
                            this.ProcessList.Add(process);
                        }

                        base.MessengerInstance.Send(new CompleteWorkMessage());
                    };

                worker.RunWorkerAsync(msg);
            }
        }
    }
}
