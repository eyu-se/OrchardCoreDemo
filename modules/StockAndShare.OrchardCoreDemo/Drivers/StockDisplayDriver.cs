using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;
using StockAndShare.OrchardCoreDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAndShare.OrchardCoreDemo.Drivers
{
    class StockDisplayDriver: DisplayDriver<StockPartViewModel>
    {

        [SuppressMessage(
            "StyleCop.CSharp.ReadabilityRules",
            "SA1114:Parameter list should follow declaration",
            Justification = "Necessary for comments.")]
        public override IDisplayResult Display(StockPartViewModel model) =>
            // For the sake of demonstration we use Combined() here. It makes it possible to return multiple shapes from
            // a driver method - won't necessarily be displayed all at once!
            Combine(
                // Here we define a shape for the Title. It's not necessary to split these to atomic pieces but it would
                // make sense to make a reusable shape for the title, and it also makes overriding just these pieces
                // possible (like you hand this module over to somebody and they want to display the title differently
                // on their site, without modifying your module). There are multiple helpers you can use to render a
                // shape (display or edit) this View() comes handy when you don't want to bother with view models (the
                // view model will be a ShapeViewModel<Book> in this case, you'll see). In the Location helper you
                // define a position for the shape. "Header" means that it will be displayed in the Header zone. "1"
                // means that it will be the first in the Header zone. Soon you will see what the zones are.
             
                View($"StockPartViewModel", model)
                    .Location("Description", "Content: 1"));

        // Now let's see what those zones are and slowly clarify all these things you've seen above!
        // NEXT STATION: Views/Book.cshtml.
    }

}
