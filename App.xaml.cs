using System;
using System.Configuration;
using System.Data;
using Microsoft.Extensions.DependencyInjection;
using EveInvestmentTrust.ViewModel;
using System.Windows;
using EveInvestmentTrust.Page;

namespace EveInvestmentTrust;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application {

    public static IServiceProvider ServiceProvider { get; private set; }

    public App() {

        var services = new ServiceCollection();

        // View Models
        services.AddSingleton<NavigationMenuViewModel>();
        services.AddSingleton<BalanceSheetViewModel>();
        services.AddSingleton<SettingsViewModel>();

        // Pages
        services.AddSingleton<BalanceSheetPage>();
        services.AddSingleton<SettingsPage>();

        // Menu items
        services.AddSingleton(sc => new List<NavigationMenuItemViewModel> {
            new NavigationMenuItemViewModel("Balance Sheet", sc.GetRequiredService<BalanceSheetPage>()),
            new NavigationMenuItemViewModel("Settings", sc.GetRequiredService<SettingsPage>())
        });

        ServiceProvider = services.BuildServiceProvider();

    }
}

