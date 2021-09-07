using Microsoft.AspNetCore.Mvc;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Records;
using StockAndShare.OrchardCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesSql;

namespace StockAndShare.OrchardCoreDemo.Controllers
{
    public class StockController : Controller
    {
        private readonly ISession _session;
        private readonly IContentManager _contentManager;
        public StockController(ISession session, IContentManager contentManager)
        {

            _session = session;
            _contentManager = contentManager;
        }

        public async Task<string> List() {
            var stocks = await _session
                 .Query<ContentItem, ContentItemIndex>(index => index.ContentType == "StockPage")
                 .ListAsync();

            foreach (var stock in stocks)
            {
                await _contentManager.LoadAsync(stock);
            }

            return string.Join(',', stocks.Select(stock => stock.As<StockPart>().CompanyName));



        }
    }
}
