using System;
using System.Threading.Tasks;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using StockAndShare.OrchardCoreDemo.Models;

namespace StockAndShare.OrchardCoreDemo.Settings
{
    public class StockPartSettingsDisplayDriver : ContentTypePartDefinitionDisplayDriver
    {
        public override IDisplayResult Edit(ContentTypePartDefinition contentTypePartDefinition, IUpdateModel updater)
        {
            if (!String.Equals(nameof(StockPart), contentTypePartDefinition.PartDefinition.Name))
            {
                return null;
            }

            return Initialize<StockPartSettingsViewModel>("StockPartSettings_Edit", model =>
            {
                var settings = contentTypePartDefinition.GetSettings<StockPartSettings>();

                model.MySetting = settings.MySetting;
                model.StockPartSettings = settings;
            }).Location("Content");
        }

        public override async Task<IDisplayResult> UpdateAsync(ContentTypePartDefinition contentTypePartDefinition, UpdateTypePartEditorContext context)
        {
            if (!String.Equals(nameof(StockPart), contentTypePartDefinition.PartDefinition.Name))
            {
                return null;
            }

            var model = new StockPartSettingsViewModel();

            if (await context.Updater.TryUpdateModelAsync(model, Prefix, m => m.MySetting))
            {
                context.Builder.WithSettings(new StockPartSettings { MySetting = model.MySetting });
            }

            return Edit(contentTypePartDefinition, context.Updater);
        }
    }
}
