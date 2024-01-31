namespace MvvmReactiveUI.ViewModels.Steps;

public class ChooseDienstViewModel : PageViewModelBase
{
    public override bool CanNavigateNext { get; }
    public override bool CanNavigatePrevious => true;
    public override bool CanFinish { get; }
}