using Practicing_WPF_APP.Core;

namespace Practicing_WPF_APP.MVVM.ViewModel;

public class MainViewModel : ObservableObject
{
    public RelayCommand HomeViewCommand { get; set; }
    public RelayCommand DiscoveryViewCommand { get; set; }
    
    
    
    private object _currentView;

    public HomeViewModel HomeVM { get; set; }

    public DiscoveryViewModel DicoveryVM { get; set; }
    
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
        DicoveryVM = new DiscoveryViewModel();
        CurrentView = HomeVM;

        HomeViewCommand = new RelayCommand(o =>
        {
            CurrentView = HomeVM;
        });
        
        DiscoveryViewCommand = new RelayCommand(o =>
        {
            CurrentView = DicoveryVM;
        });
    }
}