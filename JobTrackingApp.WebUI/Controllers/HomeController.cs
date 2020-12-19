using JobTrackingApp.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobTrackingApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskService _taskService;
        public HomeController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}