using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "StockAndShare.OrchardCoreDemo",
    Author = "The Orchard Core Team",
    Website = "https://orchardcore.net",
    Version = "0.0.1",
    Description = "StockAndShare.OrchardCoreDemo",
    Dependencies = new[] { "OrchardCore.Contents", "OrchardCore.ContentFields" },
    Category = "Content Management"
)]
