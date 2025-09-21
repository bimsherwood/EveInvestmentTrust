using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;

namespace EveInvestmentTrust.ViewModel;

public partial class NavigationMenuViewModel : ObservableObject {

    [ObservableProperty]
    private List<NavigationMenuItem> _menuItems;

    public NavigationMenuViewModel(List<NavigationMenuItem> menuItems) {
        this.MenuItems = menuItems;
    }

}
