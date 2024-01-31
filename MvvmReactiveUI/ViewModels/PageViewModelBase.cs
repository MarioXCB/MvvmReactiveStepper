using System.Windows.Input;
using ReactiveUI;

namespace MvvmReactiveUI.ViewModels;

public abstract class PageViewModelBase : ViewModelBase, IRoutableViewModel
{
    /// <summary>
    ///     Gets if the user can navigate to the next page
    /// </summary>
    public abstract bool CanNavigateNext { get; }

    /// <summary>
    ///     Gets if the user can navigate to the previous page
    /// </summary>
    public abstract bool CanNavigatePrevious { get; }
    public abstract bool CanFinish { get; }
    public string? UrlPathSegment { get; }
    public IScreen HostScreen { get; }
}