using CommunityToolkit.Mvvm.ComponentModel;

namespace EveInvestmentTrust.ViewModel;

public partial class SettingsViewModel : ObservableObject {

    [ObservableProperty]
    public string _swingWindowDaysStr;

    public int? SwingWindowDays {
        get {
            if (int.TryParse(this.SwingWindowDaysStr, out int days)) {
                return days;
            } else {
                return null;
            }
        }
    }

    public SettingsViewModel() {
        this.SwingWindowDaysStr = "90";
    }

}
