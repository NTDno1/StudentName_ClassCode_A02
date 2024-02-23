using GUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string name = HttpContext.Session.GetString("Name");
            int? roleId = HttpContext.Session.GetInt32("Role");
            if(name == null|| name == "" || roleId == 0 || roleId == null)
            {
                return Redirect($"/User/Login");
            }
            if(roleId == 2)
            {
                return RedirectToAction("ListUser", "User");
            }
            else
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
