
using CommunityToolkit.Mvvm.ComponentModel;

public partial class TransactionRowViewModel : ObservableObject {

    [ObservableProperty]
    private string _commodity;
    [ObservableProperty]
    private string _debit;
    [ObservableProperty]
    private string _credit;
    [ObservableProperty]
    private string _memo;

}