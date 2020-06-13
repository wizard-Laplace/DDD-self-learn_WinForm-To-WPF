using DDD.WPF.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace DDD.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            this.DispatcherUnhandledException
                += App_DispatcherUnhandledException;
        }

        private void App_DispatcherUnhandledException(
            object sender,
            System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            //e.Exception.Message("地域を選択してください");
            MessageBox.Show(
                e.Exception.Message, 
                "メッセージ", 
                MessageBoxButton.OK,
                MessageBoxImage.Information);
            e.Handled = true;
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<WeatherLatestView>();
        }
    }
}
