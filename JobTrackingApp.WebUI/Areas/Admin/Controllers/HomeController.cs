using Microsoft.AspNetCore.Mvc;

namespace JobTrackingApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            TempData["Active"] = "Home";
            return View();
        }
    }
}