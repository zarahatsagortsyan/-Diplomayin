using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EquipmentShop.Models;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Authorization;

namespace EquipmentShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }
        [Authorize]
        public IActionResult Index()
        {
            //return View();
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/Admin/Home/HeadSection");
                //return Content(User.Identity.Name);
            }
            return Content("не аутентифицирован");

        }

        public IActionResult Logined()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    return Content(User.Identity.Name);
            //}
            return Content("не аутентифицирован");
        }
        public IActionResult Privacy()
        {
            return Content("Authorized");
        }
        //public IActionResult Privacy()
        //{
        //    return View();
        //}



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
