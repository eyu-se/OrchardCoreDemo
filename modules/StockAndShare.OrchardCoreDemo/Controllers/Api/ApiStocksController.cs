using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display;
using OrchardCore.DisplayManagement.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace StockAndShare.OrchardCoreDemo.Controllers.Api
{
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    [ApiController]
    public class MyApiController : Controller
    {
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult Get()
        {
            var itemsList = new List<string>{
                "Item 1",
                "Item 2",
                "Item 3"
            };

            return Ok(itemsList);
        }
    }
}
