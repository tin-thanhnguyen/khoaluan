﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebForum.Services;

namespace WebForum.Extensions
{
    public static class CustomHelpers
    {
        public class LoaiBaiVietSelectItem : SelectListItem
        {
            public string Class { get; set; }
            public string Disabled { get; set; }
            public string SelectedValue { get; set; }
        }

        public static MvcHtmlString LoaiBaiVietDropdownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string selectedValue, string optionLabel, object htmlAttributes = null)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            string name = ExpressionHelper.GetExpressionText((LambdaExpression)expression);
            return LoaiBaiVietDropdownList(htmlHelper, metadata, name, optionLabel, selectedValue);
        }

        private static MvcHtmlString LoaiBaiVietDropdownList(this HtmlHelper htmlHelper, ModelMetadata metadata, string name, string optionLabel, string selectedValue)
        {
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException("name");
            }

            TagBuilder dropdown = new TagBuilder("select");
            dropdown.Attributes.Add("name", fullName);
            dropdown.MergeAttribute("data-val", "true");
            dropdown.MergeAttribute("data-val-required", "Mandatory field.");
            dropdown.MergeAttribute("data-val-number", "The field must be a number.");
            dropdown.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(name, metadata));

            StringBuilder options = new StringBuilder();

            // Make optionLabel the first item that gets rendered.
            if (optionLabel != null)
                options.Append("<option value='" + String.Empty + "'>" + optionLabel + "</option>");
            DanhMucServices services = new DanhMucServices();

            foreach (var item in services.GetDanhMucForSelect().Select(m=>new LoaiBaiVietSelectItem() {
                 Text=m.Text,
                  Value=m.Value
            }))
            {
                if (item.SelectedValue == "selected" && item.Disabled == "disabled")
                    options.Append("<option value='" + item.Value + "' class='" + item.Class + "' selected='" + item.SelectedValue + "' disabled='" + item.Disabled + "'>" + item.Text + "</option>");
                else if (item.SelectedValue != "selected" && item.Disabled == "disabled")
                    options.Append("<option value='" + item.Value + "' class='" + item.Class + "' disabled='" + item.Disabled + "'>" + item.Text + "</option>");
                else if (item.SelectedValue == "selected" && item.Disabled != "disabled")
                    options.Append("<option value='" + item.Value + "' class='" + item.Class + "' selected='" + item.SelectedValue + "'>" + item.Text + "</option>");
                else
                    options.Append("<option value='" + item.Value + "' class='" + item.Class + "'>" + item.Text + "</option>");
            }
            dropdown.InnerHtml = options.ToString();
            return MvcHtmlString.Create(dropdown.ToString(TagRenderMode.Normal));
        }
    }
}