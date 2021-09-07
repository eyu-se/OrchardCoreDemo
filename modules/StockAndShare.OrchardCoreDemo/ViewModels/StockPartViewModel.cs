using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using OrchardCore.ContentManagement;
using StockAndShare.OrchardCoreDemo.Models;
using StockAndShare.OrchardCoreDemo.Settings;

namespace StockAndShare.OrchardCoreDemo.ViewModels
{
    public class StockPartViewModel
    {
        public string MySetting { get; set; }

        [Required]
        
        public string CompanyName { get; set; }

        [Required]
        public double CurrentStockPrice { get; set; }

        [Required]
        public DateTime? RecordedDate { get; set; }

        public bool Show { get; set; }

        [BindNever]
        public ContentItem ContentItem { get; set; }

        [BindNever]
        public StockPart StockPart { get; set; }

        [BindNever]
        public StockPartSettings Settings { get; set; }
    }
}
