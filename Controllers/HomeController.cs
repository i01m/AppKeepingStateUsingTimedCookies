using AppKeepingStateUsingTimedCookies.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace AppKeepingStateUsingTimedCookies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private const string cookieKey = "myData";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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


        [HttpPost]
        public IActionResult Index(string value)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(1);

            Response.Cookies.Append(cookieKey, value, options);

            return View();
        }

        public IActionResult Test()
        {
            string value = Request.Cookies[cookieKey];
            return View(value as object);
        }
    }
}
