using System;
using Fluid;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Handlers;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Data.Migration;
using StockAndShare.OrchardCoreDemo.Drivers;
using StockAndShare.OrchardCoreDemo.Handlers;
using StockAndShare.OrchardCoreDemo.Models;
using StockAndShare.OrchardCoreDemo.Settings;
using StockAndShare.OrchardCoreDemo.ViewModels;
using OrchardCore.Modules;

namespace StockAndShare.OrchardCoreDemo
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.Configure<TemplateOptions>(o =>
            {
                o.MemberAccessStrategy.Register<StockPartViewModel>();
            });

            services.AddContentPart<StockPart>()
                .UseDisplayDriver<StockPartDisplayDriver>()
                .AddHandler<StockPartHandler>();

            services.AddScoped<IContentTypePartDefinitionDisplayDriver, StockPartSettingsDisplayDriver>();
            services.AddScoped<IDataMigration, Migrations>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "Home",
                areaName: "StockAndShare.OrchardCoreDemo",
                pattern: "Home/Index",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
