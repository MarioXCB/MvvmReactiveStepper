using System.Configuration;
using System.Data;
using System.Reflection;
using System.Windows;
using MvvmReactiveUI.Utils;
using MvvmReactiveUI.Views;
using ReactiveUI;
using Splat;

namespace MvvmReactiveUI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private void OnApplicationStartup(object sender, StartupEventArgs e)
    {
        Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetExecutingAssembly());
        Locator.CurrentMutable.RegisterLazySingleton(() => new AppViewLocator(), typeof(IViewLocator));

        Stepper stepper = new Stepper();
        stepper.Show();
    }
}