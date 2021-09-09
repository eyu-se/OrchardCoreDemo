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

namespace StockAndShare.OrchardCoreDemo.Controllers
{
    [ApiController]
    class ApiStocksController : Controller
    {

        private readonly ISession _session;
        private readonly IContentManager _contentManager;
        private readonly IContentItemDisplayManager _contentItemDisplayManager;
        private readonly IUpdateModelAccessor _updateModelAccessor;
        public ApiStocksController(ISession session, IContentManager contentManager, IContentItemDisplayManager contentItemDisplayManager, IUpdateModelAccessor updateModelAccessor)
        {

            _session = session;
            _contentManager = contentManager;
            _contentItemDisplayManager = contentItemDisplayManager;
            _updateModelAccessor = updateModelAccessor;
        }

        [HttpGet, ActionName("Get")]
        public async Task<IActionResult> Get()
        {
            

            return Ok("HEy");
        }
    }
}
