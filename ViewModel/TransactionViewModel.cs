using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace EveInvestmentTrust.ViewModel;

public partial class TransactionViewModel : ObservableObject {

    private readonly Action CloseModal;

    [ObservableProperty]
    public string _swingWindowDaysStr;

    public TransactionViewModel(Action closeModal) {
        this.CloseModal = closeModal;
        this.SwingWindowDaysStr = "90";
    }

    [RelayCommand]
    private async Task Close() {
        this.CloseModal();
    }

}
