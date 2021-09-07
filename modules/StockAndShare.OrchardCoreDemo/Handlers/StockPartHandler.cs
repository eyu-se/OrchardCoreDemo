using OrchardCore.ContentManagement.Handlers;
using System.Threading.Tasks;
using StockAndShare.OrchardCoreDemo.Models;

namespace StockAndShare.OrchardCoreDemo.Handlers
{
    public class StockPartHandler : ContentPartHandler<StockPart>
    {
        public override Task InitializingAsync(InitializingContentContext context, StockPart part)
        {
            part.Show = true;

            return Task.CompletedTask;
        }

        public override Task UpdatedAsync(UpdateContentContext context, StockPart instance)
        {
            context.ContentItem.DisplayText = instance.CompanyName;

            return Task.CompletedTask;
        }
    }
}