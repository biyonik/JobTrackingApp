using Microsoft.AspNetCore.Mvc;

namespace JobTrackingApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}