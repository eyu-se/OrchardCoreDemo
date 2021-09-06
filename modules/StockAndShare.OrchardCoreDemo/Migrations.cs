using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.Data.Migration;
using StockAndShare.OrchardCoreDemo.Models;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;

namespace StockAndShare.OrchardCoreDemo
{
    public class Migrations : DataMigration
    {
        IContentDefinitionManager _contentDefinitionManager;

        public Migrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public int Create()
        {
            _contentDefinitionManager.AlterPartDefinition(nameof(StockPart), builder => builder
                .Attachable()
                .WithField(nameof(StockPart.Description), field => field
                .OfType(nameof(TextField))
                .WithDisplayName("Stock Description")
                .WithSettings(new TextFieldSettings {
                    Hint = "Stocks Description"
                })
                .WithEditor("TextArea"))
                .WithDescription("Stock listings from external APIs")
                );

            _contentDefinitionManager.AlterTypeDefinition("StockPage", type  => type
            .Creatable()
            .Listable()
            .WithPart(nameof(StockPart)));

            return 1;
        }
    }
}
