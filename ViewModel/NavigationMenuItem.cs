using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace EveInvestmentTrust.ViewModel;

public partial class NavigationMenuItem : ObservableObject
{

    [ObservableProperty]
    private string _name;
    [ObservableProperty]
    private object _pageViewModel;

    public NavigationMenuItem(string name, object pageViewModel)
    {
        Name = name;
        PageViewModel = pageViewModel;
    }
    
}
