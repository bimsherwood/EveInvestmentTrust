namespace EveInvestmentTrust.ViewModel;

public class SettingsViewModel
{
    public string ApiKey { get; set; }
    public string DefaultCurrency { get; set; }
    public bool EnableNotifications { get; set; }
    public int RefreshIntervalMinutes { get; set; }
}
