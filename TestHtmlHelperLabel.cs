//PROOF OF CONCEPT
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMiniApp
{
    public class TestHtmlHelperLabel
    {
        public static MvcHtmlString TestEditorFor(string text)
        {
            var tagBuilder = new TagBuilder("label");
            tagBuilder.AddCssClass("myLabel");
            tagBuilder.InnerHtml = text;
            return new MvcHtmlString(tagBuilder.ToString());
        }
    }
}
