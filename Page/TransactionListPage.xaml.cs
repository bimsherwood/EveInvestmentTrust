using System.Windows.Controls;
using EveInvestmentTrust.ViewModel;

namespace EveInvestmentTrust.Page;

public partial class TransactionListPage : UserControl {

    public TransactionListPage(TransactionListViewModel viewModel) {
        this.DataContext = viewModel;
        InitializeComponent();
    }
    
}
