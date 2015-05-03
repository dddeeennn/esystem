using System.Web.Mvc;

namespace EGCad.Controllers
{
    public class NavigationController : Controller
    {
		public ActionResult Menu()
		{
			return PartialView();
		}
    }
}