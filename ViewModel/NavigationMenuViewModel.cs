using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace EveInvestmentTrust.ViewModel;

public partial class NavigationMenuViewModel : ObservableObject {

    [ObservableProperty]
    private List<NavigationMenuItemViewModel> _menuItems;

    [ObservableProperty]
    private object _currentPage;

    [ObservableProperty]
    private string _currentTitle;

    public NavigationMenuViewModel(List<NavigationMenuItemViewModel> menuItems) {
        this.MenuItems = menuItems;
        this.CurrentPage = menuItems.First().Page;
        this.CurrentTitle = menuItems.First().Name;
    }

    [RelayCommand]
    private void Navigate(NavigationMenuItemViewModel? selection) {
        if (selection is not null) {
            this.CurrentPage = selection.Page;
            this.CurrentTitle = selection.Name;
        }
    }

}
