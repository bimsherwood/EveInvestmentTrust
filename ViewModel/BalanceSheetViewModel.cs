using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace EveInvestmentTrust.ViewModel;

public partial class BalanceSheetViewModel : ObservableObject {

    [ObservableProperty]
    public List<BalanceSheetLineItemViewModel> _lineItems;

    private readonly ModalService ModalService;

    public BalanceSheetViewModel(ModalService modalService) {
        this.ModalService = modalService;
        this.LineItems = new List<BalanceSheetLineItemViewModel>();
    }

    [RelayCommand]
    private async Task NewTransaction() {
        await this.ModalService.OpenTransaction();
    }

}