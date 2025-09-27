using System.Windows.Controls;
using EveInvestmentTrust.ViewModel;

namespace EveInvestmentTrust.Page;

public partial class SettingsPage : UserControl  {
    public SettingsPage(SettingsViewModel viewModel) {
        this.DataContext = viewModel;
        InitializeComponent();
    }
}
