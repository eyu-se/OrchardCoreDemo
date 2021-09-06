using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace StockAndShare.OrchardCoreDemo.Settings
{
    public class StockPartSettingsViewModel
    {
        public string MySetting { get; set; }

        [BindNever]
        public StockPartSettings StockPartSettings { get; set; }
    }
}
