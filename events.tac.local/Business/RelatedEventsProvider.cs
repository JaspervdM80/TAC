using events.tac.local.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TAC.Sitecore.Abstractions.Interfaces;
using TAC.Sitecore.Abstractions.SitecoreImplementation;

namespace events.tac.local.Business
{
    public class RelatedEventsProvider
    {
        private IRenderingContext _context;

        public RelatedEventsProvider() : this(SitecoreRenderingContext.Create()) { }

        public RelatedEventsProvider(IRenderingContext context)
        {
            _context = context;
        }

        public IEnumerable<NavigationItem> GetRelatedEvents()
        {
            var items = _context.ContextItem.GetMultilistFieldItems("relatedEvents").ToList();

            return items.Select(i =>
                                new NavigationItem(
                                    i.DisplayName,
                                    i.Url,
                                    true
                                    ));
        }

    }
}