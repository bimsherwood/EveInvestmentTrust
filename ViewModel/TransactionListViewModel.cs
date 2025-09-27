using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

public partial class TransactionListViewModel : ObservableObject {

    [ObservableProperty]
    private ObservableCollection<TransactionRowViewModel> _transactions;

    private ModalService ModalService;

    public TransactionListViewModel(ModalService navigationService) {
        _transactions = new ObservableCollection<TransactionRowViewModel>();
        this.ModalService = navigationService;
    }

    [RelayCommand]
    private async Task NewTransaction() {
        var newTrans = await this.ModalService.OpenTransaction();
        if (newTrans != null) {
            var newRow = new TransactionRowViewModel();
            newRow.Commodity = newTrans.SelectedCommodity.Name;
            newRow.Debit = newTrans.TotalDebit?.ToString("0.##") ?? "";
            newRow.Credit = newTrans.TotalCredit?.ToString("0.##") ?? "";
            newRow.Memo = "Sugma";
            this.Transactions.Add(newRow);
        }
    }

}