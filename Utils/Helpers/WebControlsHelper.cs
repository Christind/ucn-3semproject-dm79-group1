using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Utils.Helpers
{
    public static class WebControlsHelper
    {
        /// <summary>
        /// Reset the textbox or dropdownlist controls to default value
        /// </summary>
        /// <param name="parent">The Page object (this)</param>
        public static void ResetControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                    ((TextBox)(c)).Text = string.Empty;

                else if (c.GetType() == typeof(DropDownList))
                    ((DropDownList)(c)).SelectedIndex = 0;

                if (c.HasControls())
                    ResetControls(c);
            }
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string src, string altText)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", src);
            builder.MergeAttribute("alt", altText);

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string src, string altText, string classes, string title, string style = "")
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", src);
            builder.MergeAttribute("alt", altText);
            builder.MergeAttribute("class", classes);
            builder.MergeAttribute("title", title);
            builder.MergeAttribute("style", style);

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}
