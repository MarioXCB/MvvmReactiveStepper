using System.Windows.Input;
using DynamicData;
using MvvmReactiveUI.ViewModels.Steps;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Serilog;

namespace MvvmReactiveUI.ViewModels;

public class StepperViewModel : ViewModelBase, IScreen
{
    public RoutingState Router { get; }
    
    private PageViewModelBase _currentPage;
    public PageViewModelBase[] Pages { get; set; }
    
    [Reactive]
    public PageViewModelBase CurrentPage
    {
        get;
        set;
    }
    
    public ICommand NavigateNextCommand { get; }

    /// <summary>
    ///     Gets a command that navigates to the previous page
    /// </summary>
    public ICommand NavigatePreviousCommand { get; }
    public ICommand FinishCommand { get; set; }


    public StepperViewModel()
    {
        Router = new RoutingState();
        Pages = new PageViewModelBase[]
        {
            new DateStepViewModel(),
            new ChooseDienstViewModel()
        };
        CurrentPage = Pages[0];
        
        
        Router.Navigate.Execute(CurrentPage);
        
        var canNavNext = this.WhenAnyValue(x => x.CurrentPage.CanNavigateNext);
        var canNavPrev = this.WhenAnyValue(x => x.CurrentPage.CanNavigatePrevious);
        var canFinish = this.WhenAnyValue(x => x.CurrentPage.CanFinish);
        
        NavigateNextCommand = ReactiveCommand.Create(NavigateNext, canNavNext);
        NavigatePreviousCommand = ReactiveCommand.Create(NavigatePrevious, canNavPrev);
        FinishCommand = ReactiveCommand.Create(FinishStepper, canFinish);
    }


    private void FinishStepper()
    {
        Log.Information("Stepper has finished");
    }

    private void NavigatePrevious()
    {
        // get the current index and add 1
        var index = Pages.IndexOf(CurrentPage) - 1;

        //  /!\ Be aware that we have no check if the index is valid. You may want to add it on your own. /!\
        CurrentPage = Pages[index];
        Router.Navigate.Execute(CurrentPage);
    }

    private void NavigateNext()
    {
        var index = Pages.IndexOf(CurrentPage) + 1;

        //  /!\ Be aware that we have no check if the index is valid. You may want to add it on your own. /!\
        CurrentPage = Pages[index];
        Router.Navigate.Execute(CurrentPage);
    }
}