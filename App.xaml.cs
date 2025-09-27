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

        // Services
        services.AddSingleton<ModalService>();

        // View Models
        services.AddSingleton<NavigationMenuViewModel>();
        services.AddSingleton<TransactionListViewModel>();
        services.AddSingleton<BalanceSheetViewModel>();
        services.AddSingleton<SettingsViewModel>();

        // Pages
        services.AddSingleton<TitlePage>();
        services.AddSingleton<TransactionListPage>();
        services.AddSingleton<BalanceSheetPage>();
        services.AddSingleton<SettingsPage>();

        // Menu items
        services.AddSingleton(sc => new List<NavigationMenuItemViewModel> {
            new NavigationMenuItemViewModel(sc, typeof(TransactionListPage), "Transactions"),
            new NavigationMenuItemViewModel(sc, typeof(BalanceSheetPage), "Balance Sheet"),
            new NavigationMenuItemViewModel(sc, typeof(SettingsPage), "Settings")
        });

        ServiceProvider = services.BuildServiceProvider();

    }
}

