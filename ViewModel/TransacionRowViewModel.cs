
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EveInvestmentTrust.ViewModel;

public partial class TransactionRowViewModel : ObservableObject {

    [ObservableProperty]
    private bool _includesBrokerage;

    [ObservableProperty]
    private string _commodity;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Debit))]
    [NotifyPropertyChangedFor(nameof(Credit))]
    private decimal _quantity;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Debit))]
    [NotifyPropertyChangedFor(nameof(Credit))]
    private decimal _price;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Debit))]
    [NotifyPropertyChangedFor(nameof(Credit))]
    private bool _isBuy;

    [ObservableProperty]
    private string _memo;

    public string Debit => this.IsBuy
        ? (this.Quantity * this.Price).ToString("0.##")
        : "";

    public string Credit => !this.IsBuy
        ? (this.Quantity * this.Price).ToString("0.##")
        : "";

    private CommodityDataService CommodityDataService;
    private ModalService ModalService;

    public TransactionRowViewModel(
            CommodityDataService commodityDataService,
            ModalService modalService) {
        this.CommodityDataService = commodityDataService;
        this.ModalService = modalService;
    }

    [RelayCommand]
    private async Task Edit() {
        var commodityOptions = this.CommodityDataService.GetCommodities();
        var viewModel = new TransactionViewModel(commodityOptions);
        viewModel.IsBuy = this.IsBuy;
        viewModel.IncludesBrokerage = this.IncludesBrokerage;
        viewModel.Memo = this.Memo;
        viewModel.Quantity = this.Quantity;
        viewModel.Price = this.Price;
        viewModel.SelectedCommodity =
            commodityOptions.FirstOrDefault(o => o.Name == this.Commodity) ??
            commodityOptions.First();
        var acceptChanges = await this.ModalService.EditTransaction(viewModel);
        if (acceptChanges) {
            this.IsBuy = viewModel.IsBuy;
            this.IncludesBrokerage = viewModel.IncludesBrokerage;
            this.Memo = viewModel.Memo;
            this.Quantity = viewModel.Quantity ?? 0;
            this.Price = viewModel.Price ?? 0;
            this.Commodity = viewModel.SelectedCommodity.Name;
        }
    }

}