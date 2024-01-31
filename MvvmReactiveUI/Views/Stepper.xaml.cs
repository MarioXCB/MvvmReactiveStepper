using System.Reactive.Disposables;
using MvvmReactiveUI.ViewModels;
using ReactiveUI;

namespace MvvmReactiveUI.Views;

public partial class Stepper : IViewFor<StepperViewModel>
{
    public Stepper()
    {
        InitializeComponent();
        ViewModel = new StepperViewModel();
        this.WhenActivated(disposables =>
        {
            this.OneWayBind(ViewModel, x => x.Router, x => x.Router.Router)
                .DisposeWith(disposables);
            
            this.OneWayBind(ViewModel, x => x.NavigatePreviousCommand, 
                    x => x.NavigatePreviousButton.Command)
                .DisposeWith(disposables);
            this.OneWayBind(ViewModel, x => x.NavigateNextCommand, 
                    x => x.NavigateNextButton.Command)
                .DisposeWith(disposables);
        });
    }

    object? IViewFor.ViewModel
    {
        get => ViewModel;
        set => ViewModel = value as StepperViewModel;
    }

    public StepperViewModel? ViewModel { get; set; }
}