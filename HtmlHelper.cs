using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace MVCMiniApp
{
    public static class HtmlHelper
    {

        public static MvcHtmlString TestEditorFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string templateName, string htmlFieldName, object additionalViewData)
        {
            return EditorExtensions.EditorFor(html, expression, templateName, htmlFieldName, additionalViewData);
        }

        public static MvcHtmlString TestLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            return TaxLabelFor(html, expression, new RouteValueDictionary(htmlAttributes));
        }
        public static MvcHtmlString TestLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (String.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }

            TagBuilder tag = new TagBuilder("label");
            tag.MergeAttributes(htmlAttributes);
            tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));

            TagBuilder span = new TagBuilder("span");
            span.SetInnerText(labelText);

            // assign <span> to <label> inner html
            tag.InnerHtml = span.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString TestTextBoxFor<TModel, TProperty>(
         this HtmlHelper<TModel> helper,
         Expression<Func<TModel, TProperty>> expression)
        {
            return helper.TextBoxFor(expression, new { @class = "txt" });
        }

        public static MvcHtmlString TestTextAreaFor<TModel, TProperty>(
         this HtmlHelper<TModel> helper,
         Expression<Func<TModel, TProperty>> expression)
        {
            return helper.TextAreaFor(expression, new { @class = "txt" });
        }

     

        public static MvcHtmlString TestRadioButtonLabelFor<TModel, TProperty>(this HtmlHelper<TModel> self, Expression<Func<TModel, TProperty>> expression, bool value, string labelText)
        {
            // Retrieve the qualified model identifier
            string name = ExpressionHelper.GetExpressionText(expression);
            string fullName = self.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);

            // Generate the base ID
            TagBuilder tagBuilder = new TagBuilder("input");
            tagBuilder.GenerateId(fullName);
            string idAttr = tagBuilder.Attributes["id"];

            // Create an ID specific to the boolean direction
            idAttr = string.Format("{0}_{1}", idAttr, value);

            // Create the individual HTML elements, using the generated ID
            MvcHtmlString radioButton = self.RadioButtonFor(expression, value, new { id = idAttr });
            MvcHtmlString label = self.Label(idAttr, labelText);

            return new MvcHtmlString(radioButton.ToHtmlString() + label.ToHtmlString());
        }

        

        public static MvcHtmlString TestEditorFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string templateName, string htmlFieldName)
        {
            return EditorExtensions.EditorFor(html, expression, templateName, htmlFieldName);
        }

     
        public static MvcHtmlString TestEditorFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string templateName, object additionalViewData)
        {
            return EditorExtensions.EditorFor(html, expression, templateName, additionalViewData);
        }

      
        public static MvcHtmlString TestEditorForTestEditorForTestEditorFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string templateName)
        {
            return EditorExtensions.EditorFor(html, expression, templateName);
        }

      
        public static MvcHtmlString TestEditorForTestEditorFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object additionalViewData)
        {
            return EditorExtensions.EditorFor(html, expression, additionalViewData);
        }

      
        public static MvcHtmlString TestEditorFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return EditorExtensions.EditorFor(html, expression);
        }
    }
}
