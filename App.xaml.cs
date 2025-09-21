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
public partial class App : Application
{

    public static IServiceProvider ServiceProvider { get; private set; }
    
    public App()
    {
        
        var services = new ServiceCollection();
        services.AddSingleton<NavigationMenuViewModel>();
        services.AddSingleton(new List<NavigationMenuItem>
        {
            new NavigationMenuItem("Menu Item 1", null)
        });

        ServiceProvider = services.BuildServiceProvider();

    }
}

