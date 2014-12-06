using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using GrSU.ProcessExplorer.Clients.WPF.Messages;
using GrSU.ProcessExplorer.Model;

namespace GrSU.ProcessExplorer.Clients.WPF.View.Dialogs
{
    /// <summary>
    /// Interaction logic for ProcessStartDialog.xaml
    /// </summary>
    public partial class ProcessStartDialog : Elysium.Controls.Window
    {
        private bool isButtonPressed = false;
        public ProcessStartDialog()
        {
            InitializeComponent();
        }

        private void WindowClosing(object sender, CancelEventArgs e)
        {
            if (!this.isButtonPressed)
            {
                this.BtnKeepRunning.Command.Execute(null);
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            this.isButtonPressed = true;
            this.Close();
        }
    }
}
