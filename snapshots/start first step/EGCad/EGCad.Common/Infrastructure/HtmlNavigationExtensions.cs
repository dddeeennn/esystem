using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace EGCad.Common.Infrastructure
{
	public static class HtmlNavigationExtensions
	{
		/// <summary>
		/// Navigation item.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper.</param>
		/// <param name="text">The text.</param>
		/// <param name="actionName">Name of the action.</param>
		/// <param name="controllerName">Name of the controller.</param>
		/// <param name="routeValues">The route values.</param>
		/// <param name="htmlAttributes">The HTML attributes.</param>
		/// <returns></returns>
		public static MvcHtmlString NavigationItem(this HtmlHelper htmlHelper,
			string text,
			string actionName,
			string controllerName,
			object routeValues,
			object htmlAttributes)
		{
			return htmlHelper.NavigationItem(controllerName,
				htmlHelper.ActionLink(text, actionName, controllerName, routeValues, htmlAttributes));
		}

		/// <summary>
		/// Navigation item.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper.</param>
		/// <param name="text">The text.</param>
		/// <param name="actionName">Name of the action.</param>
		/// <param name="controllerName">Name of the controller.</param>
		/// <returns></returns>
		public static MvcHtmlString NavigationItem(this HtmlHelper htmlHelper,
			string text,
			string actionName,
			string controllerName)
		{
			return htmlHelper.NavigationItem(controllerName,
				htmlHelper.ActionLink(text, actionName, controllerName));
		}

		private static MvcHtmlString NavigationItem(this HtmlHelper htmlHelper,
			string controllerName,
			MvcHtmlString innerHtml)
		{
			var tag = new TagBuilder("li");

			var isCurrent = htmlHelper.IsCurrentController(controllerName);
			if (isCurrent)
			{
				tag.AddCssClass("active");
			}

			tag.InnerHtml = innerHtml.ToString();

			return MvcHtmlString.Create(tag.ToString());
		}

		private static bool IsCurrentController(this HtmlHelper htmlHelper, string controllerName)
		{
			var context = htmlHelper.ViewContext;
			while (context.ParentActionViewContext != null)
			{
				context = context.ParentActionViewContext;
			}

			var currentController = (string)context.RouteData.Values["controller"];
			return currentController.ToLowerInvariant() == controllerName.ToLowerInvariant();
		}
	}
}
