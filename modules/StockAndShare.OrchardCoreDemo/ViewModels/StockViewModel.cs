using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using OrchardCore.ContentManagement;
using StockAndShare.OrchardCoreDemo.Models;
using StockAndShare.OrchardCoreDemo.Settings;

namespace StockAndShare.OrchardCoreDemo.ViewModels
{
    public class StockViewModel
    {
      
        public string CompanyName { get; set; }

        
        public double CurrentStockPrice { get; set; }

        
        public DateTime? RecordedDate { get; set; }

        public bool Show { get; set; }

        
    }
}
