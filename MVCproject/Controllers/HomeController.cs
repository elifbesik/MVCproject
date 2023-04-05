using Microsoft.AspNetCore.Mvc;
using MVCproject.Models;

namespace MVCproject.Controllers
{
    public class HomeController : Controller
    {

        List<AppModel> AppList = new List<AppModel>()
        {
                    new AppModel { Name="BMI Calculator", Url="/BMI/BMIView", Background=@"/images/health.jpg" },
                    new AppModel { Name="Quote App", Url="/RandomQuote/RandomQuoteView", Background=@"/images/quote.jpg"},
                    new AppModel { Name="Todo App",Url="/ToDo/ToDoView", Background=@"/images/todo.jpg"},
                    new AppModel { Name="Weather App", Url="/Weather/WeatherView", Background=@"/images/weather.jpg" },

        };
     
        public IActionResult HomeView()
        {
            return View(AppList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        

    }
}
