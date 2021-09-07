using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display;
using OrchardCore.ContentManagement.Records;
using OrchardCore.DisplayManagement.ModelBinding;
using StockAndShare.OrchardCoreDemo.Models;
using StockAndShare.OrchardCoreDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YesSql;

namespace StockAndShare.OrchardCoreDemo.Controllers
{
    public class StockController : Controller
    {
        private readonly ISession _session;
        private readonly IContentManager _contentManager;
        private readonly IContentItemDisplayManager _contentItemDisplayManager;
        private readonly IUpdateModelAccessor _updateModelAccessor;
        public StockController(ISession session, IContentManager contentManager, IContentItemDisplayManager contentItemDisplayManager, IUpdateModelAccessor updateModelAccessor)
        {

            _session = session;
            _contentManager = contentManager;
            _contentItemDisplayManager = contentItemDisplayManager;
            _updateModelAccessor = updateModelAccessor;
        }
        

        public async Task<ActionResult> Index()
        {
            /*var stocks = await _session
                 .Query<ContentItem, ContentItemIndex>(index => index.ContentType == "StockPage")
                 .ListAsync();*/

            List<StockPartViewModel> stocks = new List<StockPartViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://613645c28700c50017ef550c.mockapi.io/stocks"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(apiResponse);
                    stocks = JsonConvert.DeserializeObject<List<StockPartViewModel>>(apiResponse);
                }
            }


            /* var shapes = await Task.WhenAll(stocks.Select(async stock =>
             {
                 // When you retrieve content items via ISession then you also need to run LoadAsync() on them to
                 // initialize everything.
                 var st = new StockPart()
                 {
                     CompanyName = stock.CompanyName,
                     CurrentStockPrice = stock.CurrentStockPrice,
                     RecordedDate = stock.RecordedDate,
                 };

                 var sd = await _contentManager.NewAsync(nameof(StockPart));
                 var s = sd.As<StockPart>();
                 s.As<StockPart>().CompanyName = stock.CompanyName;
                 s.As<StockPart>().CurrentStockPrice = stock.CurrentStockPrice;
                 s.As<StockPart>().RecordedDate = stock.RecordedDate;
                 s.As<StockPart>().Show = true;
                 await _contentManager.LoadAsync();


                 return await _contentItemDisplayManager.BuildDisplayAsync(s, _updateModelAccessor.ModelUpdater, "Detail");
             }));*/



            //return View(shapes);
            return View(stocks);
        }


        public async Task<ActionResult> List() {
            var stocks = await _session
                 .Query<ContentItem, ContentItemIndex>(index => index.ContentType == "StockPage")
                 .ListAsync();

            /* foreach (var stock in stocks)
             {
                 await _contentManager.LoadAsync(stock);

             }

             return string.Join(',', stocks.Select(stock => stock.As<StockPart>().CompanyName));

 */

            var shapes = await Task.WhenAll(stocks.Select(async stock =>
            {
                // When you retrieve content items via ISession then you also need to run LoadAsync() on them to
                // initialize everything.
                await _contentManager.LoadAsync(stock);

                return await _contentItemDisplayManager.BuildDisplayAsync(stock, _updateModelAccessor.ModelUpdater, "Detail");
            }));

            // Now assuming that you've already created a few Person content items on the dashboard and some of these
            // persons are more than 30 years old then this query will contain items to display.
            // NEXT STATION: Go to Views/PersonList/OlderThan30.cshtml and then come back here please.

            return View(shapes);
        }
    }
}
