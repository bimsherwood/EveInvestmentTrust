using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace EveInvestmentTrust.ViewModel;

public partial class NavigationMenuItemViewModel : ObservableObject {

    [ObservableProperty]
    private string _name;
    
    [ObservableProperty]
    private object _pageViewModel;

    public NavigationMenuItemViewModel(string name, object pageViewModel) {
        Name = name;
        PageViewModel = pageViewModel;
    }

}
