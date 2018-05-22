using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TAC.Sitecore.Abstractions.Interfaces;

namespace events.tac.local.Business
{
    public class NavigationBuilder
    {
        private IRenderingContext _context;

        public NavigationBuilder(IRenderingContext renderingContext)
        {
            _context = renderingContext;
        }

        public Models.NavigationMenuItem Build()
        {
            var root = _context?.DatasourceOrContextItem;

            return new Models.NavigationMenuItem
            (
                root?.DisplayName,
                root?.Url,
                root != null && _context?.ContextItem != null ? Build(root, _context.ContextItem) : null
            );
        }

        public IEnumerable<Models.NavigationMenuItem> Build(IItem node, IItem current)
        {

            return node
                .GetChildren()
                .Select(i => new Models.NavigationMenuItem(
                    i.DisplayName,
                    i.Url,
                    i.IsAncestorOrSelf(current) ? Build(i, current) : null
                )
            );
        }

    }
}