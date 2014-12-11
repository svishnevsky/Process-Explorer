using GalaSoft.MvvmLight;
using GrSU.ProcessExplorer.Clients.WPF.Messages;

namespace GrSU.ProcessExplorer.Clients.WPF.ViewModel
{
    public class ActivityInfoViewModel : ViewModelBase
    {
        private int activityCount;
        
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
            MessengerInstance.Register<CompleteWorkMessage>(this, OnCompleteActivity);
        }

        private void OnCompleteActivity(CompleteWorkMessage obj)
        {
            this.ActivityCount--;
        }

        private void OnStartActivity(StartWorkMessage obj)
        {
            this.ActivityCount++;
        }
    }
}
