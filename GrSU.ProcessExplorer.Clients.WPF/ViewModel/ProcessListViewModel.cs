using GrSU.ProcessExplorer.Clients.WPF.Messages;
using GrSU.ProcessExplorer.Clients.WPF.Mapping;
using GrSU.ProcessExplorer.Clients.WPF.Model.ProcessList;
using GrSU.ProcessExplorer.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using GrSU.ProcessExplorer.Clients.WPF.ViewModel.Common;
using GrSU.ProcessExplorer.Model;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace GrSU.ProcessExplorer.Clients.WPF.ViewModel
{
    public class ProcessListViewModel : BaseViewModel
    {
        private readonly Dictionary<StartedProcessAction, Action<Process>> StartedProcessActionDict = new Dictionary<StartedProcessAction, Action<Process>>();

        private readonly IProcessManager processManager;

        public ObservableCollection<ProcessListItem> ProcessList { get; set; }

        public ICommand Kill { get; private set; }

        public ProcessListViewModel(IProcessManager processManager)
        {
            this.processManager = processManager;
            this.ProcessList = new ObservableCollection<ProcessListItem>();
            MessengerInstance.Register<LoadProcessListMessage>(this, OnLoadProcessList);
            MessengerInstance.Register<ProgramClosingMessage>(this, OnProgramClosing);

            this.StartedProcessActionDict.Add(StartedProcessAction.KeepExecute, this.AddProcess);
            this.StartedProcessActionDict.Add(StartedProcessAction.Kill, this.KillProcess);

            this.Kill = new RelayCommand<ProcessListItem>(this.KillProcess);
        }

        private void OnProgramClosing(ProgramClosingMessage msg)
        {
            if (this.processManager != null)
            {
                this.processManager.Dispose();
            }
        }

        private void OnLoadProcessList(LoadProcessListMessage msg)
        {
            using (var worker = new BackgroundWorker())
            {
                worker.DoWork += (sender, args) =>
                    {
                        base.MessengerInstance.Send(new StartWorkMessage());
                        this.processManager.ProcessStart += ProcessStart;
                        this.processManager.ProcessStop += ProcessStop;
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

        private void ProcessStart(object sender, ProcessStartEventArgs e)
        {
            if (e == null || e.Process == null)
            {
                return;
            }

            base.Invoke(() => base.MessengerInstance.Send(new ProcessStartMessage(e.Process, (process, action) =>
            {
                if (!this.StartedProcessActionDict.ContainsKey(action))
                {
                    return;
                }

                this.StartedProcessActionDict[action](process);
            })));
        }

        private void AddProcess(ProcessExplorer.Model.Process process)
        {
            this.ProcessList.Add(process.Map<ProcessListItem>());
        }

        private void KillProcess(ProcessExplorer.Model.Process process)
        {
            this.processManager.KillProcess(process.Id);
        }

        private void KillProcess(ProcessListItem process)
        {
            this.processManager.KillProcess(process.Id);
        }

        private void ProcessStop(object sender, ProcessStopEventArgs e)
        {
            if (e == null || e.ProcessId == 0)
            {
                return;
            }

            var processItem = this.ProcessList.FirstOrDefault(item => item.Id == e.ProcessId);
            if (processItem == null)
            {
                return;
            }

            base.Invoke(() => this.ProcessList.Remove(processItem));
        }
    }
}
