using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobTrackingApp.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TaskOrder : Controller
    {
        // GET
        public IActionResult Index()
        {
            TempData["Active"] = "TaskOrder";
            return View();
        }
    }
}