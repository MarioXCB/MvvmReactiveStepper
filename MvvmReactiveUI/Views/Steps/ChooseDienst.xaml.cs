using System.Windows.Controls;
using MvvmReactiveUI.ViewModels.Steps;
using ReactiveUI;

namespace MvvmReactiveUI.Views.Steps;

public partial class ChooseDienst : IViewFor<ChooseDienstViewModel>
{
    public ChooseDienst()
    {
        InitializeComponent();
    }

    object? IViewFor.ViewModel
    {
        get => ViewModel;
        set => ViewModel = value as ChooseDienstViewModel;
    }

    public ChooseDienstViewModel? ViewModel { get; set; }
}