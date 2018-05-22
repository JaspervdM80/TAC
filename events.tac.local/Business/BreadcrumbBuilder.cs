using events.tac.local.Models;
using System.Collections.Generic;
using System.Linq;
using TAC.Sitecore.Abstractions.Interfaces;
using TAC.Sitecore.Abstractions.SitecoreImplementation;

namespace events.tac.local.Business
{
    public class BreadcrumbBuilder
    {
        public readonly IRenderingContext _context;

        public BreadcrumbBuilder() : this(SitecoreRenderingContext.Create()) { }
        public BreadcrumbBuilder(IRenderingContext context)
        {
            _context = context;
        }

        public IEnumerable<NavigationItem> Build()
        {
            return _context?.HomeItem == null || _context?.ContextItem == null ?

                        Enumerable.Empty<NavigationItem>() :

                        _context
                            .ContextItem
                            .GetAncestors()
                            .Where(i => _context.HomeItem.IsAncestorOrSelf(i))
                            .Select(i => new NavigationItem
                                (
                                    Title   : i.DisplayName,
                                    URL     : i.Url,
                                    Active  : false
                                ))
                            .Concat(
                                new[] {
                                    new NavigationItem
                                    (
                                        Title   : _context.ContextItem.DisplayName,
                                        URL     : _context.ContextItem.Url,
                                        Active  : true
                                    )
                                }
                            );
        }
    }
}