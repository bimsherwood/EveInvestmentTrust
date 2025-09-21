using CommunityToolkit.Mvvm.ComponentModel;

namespace EveInvestmentTrust.ViewModel;

public class BalanceSheetLineItemViewModel {

    public string Name { get; private set; }
    public decimal Amount { get; private set; }

    public BalanceSheetLineItemViewModel(string name, decimal amount) {
        this.Name = name;
        this.Amount = amount;
    }
}