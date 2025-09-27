using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace EveInvestmentTrust.ViewModel;

public partial class NavigationMenuItemViewModel : ObservableObject {

    private readonly IServiceProvider Services;
    private readonly Type PageType;

    [ObservableProperty]
    private string _name;

    public NavigationMenuItemViewModel(IServiceProvider services, Type pageType, string name) {
        this.Services = services;
        this.PageType = pageType;
        this.Name = name;
    }

    public object GetPage() {
        return this.Services.GetRequiredService(this.PageType);
    }

}
