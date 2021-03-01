using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using RelationshipsMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipsMVC.Infrastructure
{
    [HtmlTargetElement("div",Attributes ="page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory _urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext Context { get; set; }

        public Paging PageModel { get; set; }
        public string ActionName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(Context);

            TagBuilder divTag = new TagBuilder("div");
            for (int count = 1; count <= PageModel.TotalPages; count++)
            {
                TagBuilder aTag = new TagBuilder("a");

                aTag.Attributes["href"] = urlHelper.Action(ActionName, new { pagesize = count});
                aTag.InnerHtml.Append(count.ToString());
                divTag.InnerHtml.AppendHtml(aTag);
            }
            output.Content.AppendHtml(divTag);
        }
    }
}
