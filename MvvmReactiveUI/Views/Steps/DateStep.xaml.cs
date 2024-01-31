using System.Reactive.Disposables;
using MvvmReactiveUI.ViewModels.Steps;
using ReactiveUI;

namespace MvvmReactiveUI.Views.Steps;

public partial class DateStep : IViewFor<DateStepViewModel>
{
    public DateStep()
    {
        InitializeComponent();
        this.WhenActivated(disposables =>
        {
            this.Bind(ViewModel, x => x.OldEnd, x => x.DatePickerOldEnd.SelectedDate)
                .DisposeWith(disposables);
            this.Bind(ViewModel, x => x.NewStart, x => x.DatePickerNewStart.SelectedDate)
                .DisposeWith(disposables);
            this.OneWayBind(ViewModel, x => x.OldEnd, x => x.DatePickerNewStart.DisplayDateStart)
                .DisposeWith(disposables);
            this.Bind(ViewModel, x => x.NewEnd, x => x.DatePickerNewEnd.SelectedDate)
                .DisposeWith(disposables);
            this.OneWayBind(ViewModel, x => x.NewStart, x => x.DatePickerNewEnd.DisplayDateStart)
                .DisposeWith(disposables);
        });
    }

    object? IViewFor.ViewModel
    {
        get => ViewModel;
        set => ViewModel = value as DateStepViewModel;
    }

    public DateStepViewModel? ViewModel { get; set; }
}