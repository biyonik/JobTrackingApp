using Microsoft.AspNetCore.Mvc;

namespace JobTrackingApp.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}