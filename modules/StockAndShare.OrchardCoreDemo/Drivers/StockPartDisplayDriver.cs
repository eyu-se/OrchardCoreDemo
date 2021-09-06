using System.Threading.Tasks;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using StockAndShare.OrchardCoreDemo.Models;
using StockAndShare.OrchardCoreDemo.Settings;
using StockAndShare.OrchardCoreDemo.ViewModels;

namespace StockAndShare.OrchardCoreDemo.Drivers
{
    public class StockPartDisplayDriver : ContentPartDisplayDriver<StockPart>
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public StockPartDisplayDriver(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public override IDisplayResult Display(StockPart part, BuildPartDisplayContext context)
        {
            return Initialize<StockPartViewModel>(GetDisplayShapeType(context), m => BuildViewModel(m, part, context))
                .Location("Detail", "Content:10")
                .Location("Summary", "Content:10")
                ;
        }

        public override IDisplayResult Edit(StockPart part, BuildPartEditorContext context)
        {
            return Initialize<StockPartViewModel>(GetEditorShapeType(context), model =>
            BuildEditModel(model, part, context));
        }

        public override async Task<IDisplayResult> UpdateAsync(StockPart model, IUpdateModel updater)
        {
            await updater.TryUpdateModelAsync(model, Prefix, t => t.Show);

            return Edit(model);
        }

        private Task BuildViewModel(StockPartViewModel model, StockPart part, BuildPartDisplayContext context)
        {
            var settings = context.TypePartDefinition.GetSettings<StockPartSettings>();

            model.CompanyName = part.CompanyName;
            model.CurrentStockPrice = part.CurrentStockPrice;
            model.RecordedDate = part.RecordedDate;
            model.ContentItem = part.ContentItem;
            model.MySetting = settings.MySetting;
            model.Show = part.Show;
            model.StockPart = part;
            model.Settings = settings;

            return Task.CompletedTask;
        }

        private Task BuildEditModel(StockPartViewModel model, StockPart part, BuildPartEditorContext context)
        {
            var settings = context.TypePartDefinition.GetSettings<StockPartSettings>();

            model.CompanyName = part.CompanyName;
            model.CurrentStockPrice = part.CurrentStockPrice;
            model.RecordedDate = part.RecordedDate;
            model.ContentItem = part.ContentItem;
            model.MySetting = settings.MySetting;
            model.Show = part.Show;
            model.StockPart = part;
            model.Settings = settings;

            return Task.CompletedTask;
        }
    }
}
