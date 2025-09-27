using System.Collections.Generic;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EveInvestmentTrust.Page;

namespace EveInvestmentTrust.ViewModel;

public partial class NavigationMenuViewModel : ObservableObject {

    [ObservableProperty]
    private List<NavigationMenuItemViewModel> _menuItems;

    [ObservableProperty]
    private object _currentPage;

    [ObservableProperty]
    private string _currentTitle;

    [ObservableProperty]
    private Visibility _modalOpen;

    [ObservableProperty]
    private object _currentModal;

    public NavigationMenuViewModel(TitlePage titlePage, List<NavigationMenuItemViewModel> menuItems) {
        this.MenuItems = menuItems;
        this.CurrentPage = titlePage;
        this.CurrentTitle = "Eve Investment Trust";
        this.ModalOpen = Visibility.Collapsed;
        this.CurrentModal = null;
    }

    [RelayCommand]
    private void Navigate(NavigationMenuItemViewModel? selection) {
        if (selection is not null) {
            this.CurrentPage = selection.GetPage();
            this.CurrentTitle = selection.Name;
        }
    }

    public void OpenModal(object modalContent) {
        this.CurrentModal = modalContent;
        this.ModalOpen = Visibility.Visible;
    }

    public void CloseModal() {
        this.CurrentModal = null;
        this.ModalOpen = Visibility.Collapsed;
    }

}
