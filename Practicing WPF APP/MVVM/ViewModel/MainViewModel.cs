using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Practicing_WPF_APP.Core;
using Practicing_WPF_APP.MVVM.Model;

namespace Practicing_WPF_APP.MVVM.ViewModel;

public class MainViewModel : ObservableObject
{
    public RelayCommand HomeViewCommand { get; set; }
    public RelayCommand ImagesViewCommand { get; set; }
    
    public RelayCommand SunInfoCommand { get; set; }

    
    
    
    
    private object _currentView;

    public HomeViewModel HomeVM { get; set; }

    public ImagesViewModel ImagesVM { get; set; }

    public SunInfoViewModel SunInfoVM { get; set; }
    
    public object CurrentView
    {
        get { return _currentView; }
        set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }
    public MainViewModel()
    {
        HomeVM = new HomeViewModel();
        ImagesVM = new ImagesViewModel();
        SunInfoVM = new SunInfoViewModel();
        CurrentView = HomeVM;
        APIHelper.InitializeClient();

        HomeViewCommand = new RelayCommand(o =>
        {
            CurrentView = HomeVM;
        });
        
        ImagesViewCommand = new RelayCommand(o =>
        {
            CurrentView = ImagesVM;
        });
        
        SunInfoCommand = new RelayCommand(o =>
        {
            CurrentView = SunInfoVM;
        });
    }

}