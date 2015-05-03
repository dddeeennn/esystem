using System;
using System.Configuration;
using System.Reflection;
using System.Web.Mvc;

namespace EGCad.Common.Infrastructure.MVC
{
	public static class HtmlExtensions
	{
		/// <summary>
		/// Gets the version.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper.</param>
		/// <returns></returns>
		public static string GetVersion(this HtmlHelper htmlHelper)
		{
			var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

			version += ConfigurationManager.AppSettings["Configuration"];

			return version;
		}
	}
}
