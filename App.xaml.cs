using System;
using System.Configuration;
using System.Data;
using Microsoft.Extensions.DependencyInjection;
using EveInvestmentTrust.ViewModel;
using System.Windows;

namespace EveInvestmentTrust;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application {

    public static IServiceProvider ServiceProvider { get; private set; }

    public App() {

        var services = new ServiceCollection();

        // Menu items
        services.AddSingleton(sc => new List<NavigationMenuItemViewModel> {
            new NavigationMenuItemViewModel("Balance Sheet", sc.GetRequiredService<BalanceSheetViewModel>()),
            new NavigationMenuItemViewModel("Settings", sc.GetRequiredService<SettingsViewModel>())
        });

        //View Models
        services.AddSingleton<NavigationMenuViewModel>();
        services.AddSingleton<BalanceSheetViewModel>();
        services.AddSingleton<SettingsViewModel>();

        ServiceProvider = services.BuildServiceProvider();

    }
}

