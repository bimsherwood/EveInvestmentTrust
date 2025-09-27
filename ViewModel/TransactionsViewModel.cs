using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

public partial class TransactionListViewModel : ObservableObject {

    [ObservableProperty]
    private ObservableCollection<TransactionRowViewModel> _transactions;

    public TransactionListViewModel() {
        
    }

}