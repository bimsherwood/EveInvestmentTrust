
using EveInvestmentTrust.Page;
using EveInvestmentTrust.ViewModel;

public class ModalService {

    private NavigationMenuViewModel NavigationViewModel;

    public ModalService(NavigationMenuViewModel navigationViewModel) {
        this.NavigationViewModel = navigationViewModel;
    }

    public async Task OpenTransaction() {
        var viewModel = new TransactionViewModel(CloseModal);
        var modal = new TransactionModal(viewModel);
        this.NavigationViewModel.OpenModal(modal);
    }

    private void CloseModal() {
        this.NavigationViewModel.CloseModal();
    }

}