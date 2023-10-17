namespace WebApplicationADs_Eixo2.helpers
{

    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public static class NavigationHelper
    {
        public static IHtmlContent BuildNavbar(this IHtmlHelper helper, List<MenuItem> menuItems)
        {
            var ul = new TagBuilder("ul");
            ul.AddCssClass("navbar-nav");

            foreach (var menuItem in menuItems)
            {
                var li = new TagBuilder("li");
                li.AddCssClass("nav-item");

                var anchor = new TagBuilder("a");
                anchor.AddCssClass("nav-link");
                anchor.MergeAttribute("href", menuItem.Url);
                anchor.InnerHtml.Append(menuItem.Text);

                li.InnerHtml.AppendHtml(anchor);
                ul.InnerHtml.AppendHtml(li);
            }

            return ul;
        }
    }

    public class MenuItem
    {
        public string? Text { get; set; }
        public string? Url { get; set; }
    }
}
