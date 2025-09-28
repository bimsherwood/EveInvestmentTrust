using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace EveInvestmentTrust.ViewModel;

public partial class TransactionViewModel : ObservableObject {

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsSell))]
    private bool _isBuy;
    public bool IsSell => !this.IsBuy;

    [ObservableProperty]
    private bool _includesBrokerage;

    [ObservableProperty]
    private string _memo;

    [ObservableProperty]
    private List<Commodity> _commodityOptions;

    [ObservableProperty]
    private Commodity _selectedCommodity;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Quantity))]
    [NotifyPropertyChangedFor(nameof(TotalDebit))]
    [NotifyPropertyChangedFor(nameof(TotalCredit))]
    private string _quantityStr;
    public decimal? Quantity {
        get {
            if (decimal.TryParse(this.QuantityStr, out var qty)) {
                return qty;
            }
            return null;
        }
        set {
            this.QuantityStr = (value ?? 0).ToString("0.##");
        }
    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Price))]
    [NotifyPropertyChangedFor(nameof(TotalDebit))]
    [NotifyPropertyChangedFor(nameof(TotalDebit))]
    private string _priceStr;
    public decimal? Price {
        get {
            if (decimal.TryParse(this.PriceStr, out var qty)) {
                return qty;
            }
            return null;
        }
        set {
            this.PriceStr = (value ?? 0).ToString("0.##");
        }
    }

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
        this.CompleteSource = new TaskCompletionSource<bool>();
        this.IsBuy = true;
        this.IncludesBrokerage = true;
        this.Memo = "";
        this.CommodityOptions = commodtyOptions;
        this.SelectedCommodity = commodtyOptions.First();
        this.Quantity = 0;
        this.Price = 0;
    }

    [RelayCommand]
    private async Task Accept() {
        this.CompleteSource.SetResult(true);
    }

    [RelayCommand]
    private async Task Cancel() {
        this.CompleteSource.SetResult(false);
    }

}
