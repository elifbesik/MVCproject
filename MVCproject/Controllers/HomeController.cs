using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Logging;
using MVCproject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
namespace MVCproject.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        List<AppModel> AppList = new List<AppModel>()
        {
                    new AppModel { Name="BMI Calculator", Url="/Bmicalculator/App", Bg=@"/images/bmi.jpg" },
                    //new AppModel { Name="Quote App", AppUrl="/RandomWordGenerator/Index", AppBg="https://mdbcdn.b-cdn.net/img/new/standard/city/042.webp" },
                   // new AppModel { Name="Todo App",AppUrl="/Todo/Index", AppBg="https://mdbcdn.b-cdn.net/img/new/standard/city/043.webp" },
                    //new AppModel { Name="Weather App", AppUrl="/Weather/Index", AppBg="https://mdbcdn.b-cdn.net/img/new/standard/city/044.webp" },

        };


        public IActionResult Privacy()
        {
            return View();
        }

    }
}
