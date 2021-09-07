using System;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;

namespace StockAndShare.OrchardCoreDemo.Models
{
    public class StockPart : ContentPart
    {
        public string CompanyName { get; set; }
        public double CurrentStockPrice { get; set; }
        public DateTime? RecordedDate { get; set; }
        public TextField Description { get; set; }

        public bool Show { get; set; }
    }

    
}
