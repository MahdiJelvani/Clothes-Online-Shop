using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class IdentityController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IdentityController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult login()
        {
            return View();
        }

        public IActionResult signup()
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