using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;

namespace EveInvestmentTrust.ViewModel;

public partial class BalanceSheetViewModel : ObservableObject {

    [ObservableProperty]
    public List<BalanceSheetLineItemViewModel> _lineItems;

    public BalanceSheetViewModel() {
        this.LineItems = new List<BalanceSheetLineItemViewModel>();
    }
}