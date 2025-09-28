using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

public partial class TransactionListViewModel : ObservableObject {

    [ObservableProperty]
    private ObservableCollection<TransactionRowViewModel> _transactions;

    private CommodityDataService CommodityDataService;
    private ModalService ModalService;

    public TransactionListViewModel(
            CommodityDataService comodityDataService,
            ModalService navigationService) {
        this.CommodityDataService = comodityDataService;
        this.ModalService = navigationService;
        _transactions = new ObservableCollection<TransactionRowViewModel>();
    }

    [RelayCommand]
    private async Task NewTransaction() {
        var newTrans = await this.ModalService.OpenTransaction();
        if (newTrans != null) {
            var newRow = new TransactionRowViewModel(this.CommodityDataService, this.ModalService);
            newRow.Commodity = newTrans.SelectedCommodity.Name;
            newRow.Quantity = newTrans.Quantity ?? 0;
            newRow.Price = newTrans.Price ?? 0;
            newRow.IsBuy = newTrans.IsBuy;
            newRow.IncludesBrokerage = newTrans.IncludesBrokerage;
            newRow.Memo = newTrans.Memo;
            this.Transactions.Add(newRow);
        }
    }

}