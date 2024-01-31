using System;
using ReactiveUI;
using Serilog;

namespace MvvmReactiveUI.Utils;

public class AppViewLocator : IViewLocator
{
    public IViewFor? ResolveView<T>(T? viewModel, string? contract = null)
    {
        // Find view's by chopping of the 'Model' on the view model name
        // MyApp.ShellViewModel => MyApp.ShellView
        var viewModelName = viewModel.GetType().FullName;
        var viewTypeName = viewModelName.Replace("ViewModels", "Views").TrimEnd("ViewModel".ToCharArray());

        try
        {
            var viewType = Type.GetType(viewTypeName);
            if (viewType == null)
            {
                Log.Error($"Could not find the view {viewTypeName} for view model {viewModelName}.");
                return null;
            }
            
            var test =Activator.CreateInstance(viewType) as IViewFor;
            test.ViewModel = viewModel;

            return test;
        }
        catch (Exception)
        {
            Log.Error($"Could not instantiate view {viewTypeName}.");
            throw;
        }
    }
}