using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GrSU.ProcessExplorer.Clients.WPF.Messages;
using GrSU.ProcessExplorer.Clients.WPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            this.ActivityInfoArea.Content = SimpleIoc.Default.GetInstance<ActivityInfoView>();

            Messenger.Default.Send(new LoadProcessListMessage());
        }
    }
}
