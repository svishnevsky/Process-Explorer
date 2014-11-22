using GalaSoft.MvvmLight;
using GrSU.ProcessExplorer.Clients.WPF.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.ProcessExplorer.Clients.WPF.ViewModel
{
    public class ActivityInfoViewModel : ViewModelBase
    {
        private int activityCount = 0;
        
        public int ActivityCount
        {
            get { return this.activityCount; }
            set
            {
                this.activityCount = value;
                RaisePropertyChanged(() => IsActiveOperation);
            }
        }

        public bool IsActiveOperation
        {
            get
            {
                return this.ActivityCount > 0;
            }
        }

        public ActivityInfoViewModel()
        {
            MessengerInstance.Register<StartWorkMessage>(this, OnStartActivity);
            MessengerInstance.Register<CompleteWorkMessage>(this, OnCompleteActivvity);
        }

        private void OnCompleteActivvity(CompleteWorkMessage obj)
        {
            this.ActivityCount--;
        }

        private void OnStartActivity(StartWorkMessage obj)
        {
            this.ActivityCount++;
        }
    }
}
