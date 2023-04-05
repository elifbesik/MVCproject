using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MVCproject.Models;

namespace MVCproject.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult WeatherView()
        {
            List<WeatherInfo> weatherApiInfo = new List<WeatherInfo>()
            {
                new WeatherInfo{CityName="London"},
                new WeatherInfo{CityName="Istanbul"},
                new WeatherInfo{CityName="Italy"},
                new WeatherInfo{CityName="Paris"},
            };
            string AppId = "6f8b95ffcf7f1c2ac0cab4e53b818d4a";
            HttpClient client = new HttpClient();
            List<HttpResponseMessage> response = new List<HttpResponseMessage>();
            List<RootObject> weatherInfo = new List<RootObject>();
            List<string> apiUrl = new List<string>();
            List<WeatherViewModel> weatherResult = new List<WeatherViewModel>();

            for (int i = 0; i < weatherApiInfo.Count; i++)
            {

                apiUrl.Add(string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&cnt=1&APPID={1}", weatherApiInfo[i].CityName, AppId));
                response.Add(client.GetAsync(apiUrl[i]).Result);
                weatherInfo.Add(JsonConvert.DeserializeObject<RootObject>(response[i].Content.ReadAsStringAsync().Result));
                weatherResult.Add(new WeatherViewModel
                {

                    Country = weatherInfo[i].Sys.Country,
                    City = weatherInfo[i].Name,
                    Lat = Convert.ToString(weatherInfo[i].Coord.Lat),
                    Lon = Convert.ToString(weatherInfo[i].Coord.Lon),
                    Description = weatherInfo[i].Weather[0].Description,
                    Humidity = Convert.ToString(weatherInfo[i].Main.Humidity),
                    Temp = Convert.ToString(Convert.ToInt32(weatherInfo[i].Main.Temp)),
                    TempFeelsLike = Convert.ToString(weatherInfo[i].Main.Feels_like),
                    TempMax = Convert.ToString(weatherInfo[i].Main.Temp_max),
                    TempMin = Convert.ToString(weatherInfo[i].Main.Temp_min),

                    WeatherIcon = weatherInfo[i].Weather[0].Icon,
                    WindSpeed = Convert.ToString(weatherInfo[i].Wind.Speed),
                    Cloud = Convert.ToString(weatherInfo[i].Clouds.All),
                    

                });

            }
            return View(weatherResult);
        }
      

    }
}
