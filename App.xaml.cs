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
        services.AddSingleton(sc => new List<NavigationMenuItem> {
            new NavigationMenuItem("Balance Sheet", sc.GetRequiredService<BalanceSheetViewModel>())
        });

        //View Models
        services.AddSingleton<NavigationMenuViewModel>();
        services.AddSingleton<BalanceSheetViewModel>();

        ServiceProvider = services.BuildServiceProvider();

    }
}

