using ReactiveUI.Fody.Helpers;

namespace MvvmReactiveUI.ViewModels.Steps;
public class DateStepViewModel : PageViewModelBase
{
    public override bool CanNavigateNext
    {
        get => true;
    }

    [Reactive]
    public DateTime? OldEnd { get; set; }
    [Reactive]
    public DateTime? NewStart { get; set; }
    [Reactive]
    public DateTime? NewEnd { get; set; }
    
    public override bool CanNavigatePrevious => false;
    public override bool CanFinish => false;
}