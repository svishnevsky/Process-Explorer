using System.Windows;
using Elysium;
using System.Windows.Media;
using GalaSoft.MvvmLight.Ioc;
using GrSU.ProcessExplorer.Clients.WPF.View;
using GalaSoft.MvvmLight.Messaging;
using GrSU.ProcessExplorer.Clients.WPF.Messages;
using GalaSoft.MvvmLight.Threading;
using GrSU.ProcessExplorer.Clients.WPF.Helpers;
using System.Reflection;
using GrSU.ProcessExplorer.Clients.WPF.Properties;

namespace GrSU.ProcessExplorer.Clients.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public DialogManager DialogManager { get; private set; }

        private void ApplicationDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Occurred an error");
            e.Handled = true;
            //TODO: Log error
        }

        private void StartupHandler(object sender, StartupEventArgs e)
        {
            RegistryHelpers.AddToAutorun(Settings.Default.AppName, Assembly.GetExecutingAssembly().Location);
            DispatcherHelper.Initialize();
            this.Apply(Theme.Light, AccentBrushes.Blue, new SolidColorBrush(Colors.White));
            SimpleIoc.Default.Register<ProcessListView>();
            SimpleIoc.Default.Register<TrustedProcessListView>();
            SimpleIoc.Default.Register<ActivityInfoView>();

            this.DialogManager = new DialogManager();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Messenger.Default.Send(new ProgramClosingMessage());
            base.OnExit(e);
        }
    }
}
