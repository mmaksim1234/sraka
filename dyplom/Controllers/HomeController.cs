using AspNetCore;
using dyplom.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace dyplom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult services()
        {
            return View();
        }
        public IActionResult posluga30k()
        {
            return View();

        }
        public IActionResult posluga20000() 
        {
            return View();
        }
        public IActionResult ODM()
        {
            return View();
        }
        public IActionResult contusia() {
            return View();
        }
        public IActionResult poslyga50() 
            {
            return View();

            }
        public IActionResult withoutubd()
        {
            return View();

        }
        public IActionResult pilhu()
        {
            return View();

        }
        public IActionResult reabilitation()
        {
            return View();

        }
        public IActionResult ohd()
        {
            return View();

        }
        public IActionResult Index()
        {
            ViewBag.IsLoggedIn = !string.IsNullOrEmpty(HttpContext.Session.GetString("Id"));
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
