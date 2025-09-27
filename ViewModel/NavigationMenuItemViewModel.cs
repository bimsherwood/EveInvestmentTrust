using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace EveInvestmentTrust.ViewModel;

public partial class NavigationMenuItemViewModel : ObservableObject {

    [ObservableProperty]
    private string _name;
    
    [ObservableProperty]
    private object _page;

    public NavigationMenuItemViewModel(string name, object page) {
        this.Name = name;
        this.Page = page;
    }

}
