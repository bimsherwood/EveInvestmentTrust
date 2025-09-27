using System.Windows.Controls;
using EveInvestmentTrust.ViewModel;

namespace EveInvestmentTrust.Page;

public partial class TransactionModal : UserControl  {
    public TransactionModal(TransactionViewModel viewModel) {
        this.DataContext = viewModel;
        InitializeComponent();
    }
}
