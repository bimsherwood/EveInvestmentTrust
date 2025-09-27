
using EveInvestmentTrust.Page;
using EveInvestmentTrust.ViewModel;

public class ModalService {

    private NavigationMenuViewModel NavigationViewModel;
    private CommodityDataService CommodityService;

    public ModalService(
            NavigationMenuViewModel navigationViewModel,
            CommodityDataService commodityService) {
        this.NavigationViewModel = navigationViewModel;
        this.CommodityService = commodityService;
    }

    public async Task<TransactionViewModel?> OpenTransaction() {
        var commodities = this.CommodityService.GetCommodities();
        var viewModel = new TransactionViewModel(commodities);
        var modal = new TransactionModal(viewModel);
        this.NavigationViewModel.OpenModal(modal);
        var success = await viewModel.Complete;
        this.NavigationViewModel.CloseModal();
        return success ? viewModel : null;
    }

}