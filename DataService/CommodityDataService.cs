public class CommodityDataService {

    public CommodityDataService() {

    }

    public List<Commodity> GetCommodities() {
        var commodities = new List<Commodity>();
        commodities.Add(new Commodity { Id = 1, Name = "Compressed Veldspar" });
        commodities.Add(new Commodity { Id = 2, Name = "Compressed Scordite" });
        return commodities;
    }

}