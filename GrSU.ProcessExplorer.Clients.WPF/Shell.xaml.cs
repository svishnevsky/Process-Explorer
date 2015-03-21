using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GrSU.ProcessExplorer.Clients.WPF.Messages;
using GrSU.ProcessExplorer.Clients.WPF.View;

namespace GrSU.ProcessExplorer.Clients.WPF
{
    /// <summary>
    /// Interaction logic for Shellxaml.xaml
    /// </summary>
    public partial class Shell : Elysium.Controls.Window
    {
        public Shell()
        {
            InitializeComponent();
            this.ProcessListArea.Content = SimpleIoc.Default.GetInstance<ProcessListView>();
            this.TrustedProcessListArea.Content = SimpleIoc.Default.GetInstance<TrustedProcessListView>();
            this.ActivityInfoArea.Content = SimpleIoc.Default.GetInstance<ActivityInfoView>();

            Messenger.Default.Send(new LoadProcessListMessage());
        }
    }
}
