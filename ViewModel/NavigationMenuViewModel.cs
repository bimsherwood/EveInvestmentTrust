using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace EveInvestmentTrust.ViewModel;

public partial class NavigationMenuViewModel : ObservableObject {

    [ObservableProperty]
    private List<NavigationMenuItemViewModel> _menuItems;

    [ObservableProperty]
    private object _currentPageViewModel;

    public NavigationMenuViewModel(List<NavigationMenuItemViewModel> menuItems) {
        this.MenuItems = menuItems;
        this.CurrentPageViewModel = menuItems.First().PageViewModel;
    }

    [RelayCommand]
    private void Navigate(NavigationMenuItemViewModel? selection) {
        if (selection is not null) {
            this.CurrentPageViewModel = selection.PageViewModel;
        }
    }

}
