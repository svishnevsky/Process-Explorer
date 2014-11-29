/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:GrSU.ProcessExplorer.Clients.WPF"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GrSU.ProcessExplorer.Clients.WPF.View;
using GrSU.ProcessExplorer.Core;
using GrSU.ProcessExplorer.Interfaces;
using Microsoft.Practices.ServiceLocation;

namespace GrSU.ProcessExplorer.Clients.WPF.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {            
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
                //SimpleIoc.Default.Register<IDataService, DesignDataService>();
            }
            else
            {
                // Create run time view services and models
                SimpleIoc.Default.Register<IProcessManager, ProcessManager>();
            }

            SimpleIoc.Default.Register<ShellViewModel>();
            SimpleIoc.Default.Register<ProcessListViewModel>();
            SimpleIoc.Default.Register<ActivityInfoViewModel>();
            SimpleIoc.Default.Register<ProcessStartDialogViewModel>();
        }

        public ShellViewModel Shell
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ShellViewModel>();
            }
        }

        public ProcessListViewModel ProcessList
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ProcessListViewModel>();
            }
        }

        public ActivityInfoViewModel ActivityInfo
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ActivityInfoViewModel>();
            }
        }

        public ProcessStartDialogViewModel ProcessStartDialog
        {
            get 
            { 
                return ServiceLocator.Current.GetInstance<ProcessStartDialogViewModel>(); 
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}