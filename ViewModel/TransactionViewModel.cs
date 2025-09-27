using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace EveInvestmentTrust.ViewModel;

public partial class TransactionViewModel : ObservableObject {

    [ObservableProperty]
    private bool _isBuy;

    [ObservableProperty]
    private List<Commodity> _commodityOptions;

    [ObservableProperty]
    private Commodity _selectedCommodity;

    [ObservableProperty]
    private string _quantityStr;

    [ObservableProperty]
    private string _priceStr;

    [ObservableProperty]
    private bool _includesBrokerage;

    public decimal? TotalDebit {
        get {
            if (!decimal.TryParse(this.QuantityStr, out var qty)) return null;
            if (!decimal.TryParse(this.PriceStr, out var price)) return null;
            return this.IsBuy ? (qty * price) : null;
        }
    }

    public decimal? TotalCredit{
        get {
            if (!decimal.TryParse(this.QuantityStr, out var qty)) return null;
            if (!decimal.TryParse(this.PriceStr, out var price)) return null;
            return !this.IsBuy ? (qty * price) : null;
        }
    }

    private TaskCompletionSource<bool> CompleteSource;
    public Task<bool> Complete => CompleteSource.Task;

    public TransactionViewModel(List<Commodity> commodtyOptions) {
        this.IsBuy = true;
        this.CompleteSource = new TaskCompletionSource<bool>();
        this.CommodityOptions = commodtyOptions;
        this.SelectedCommodity = commodtyOptions.First();
        this.QuantityStr = "0";
        this.PriceStr = "0";
        this.IncludesBrokerage = true;
    }

    [RelayCommand]
    private async Task Create() {
        this.CompleteSource.SetResult(true);
    }

    [RelayCommand]
    private async Task Cancel() {
        this.CompleteSource.SetResult(false);
    }

}
