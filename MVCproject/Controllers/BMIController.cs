using Microsoft.AspNetCore.Mvc;
using MVCproject.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MVCproject.Controllers
{
    public class BMIController : Controller
    {
        [HttpGet]
        public IActionResult BMIView()
        {
            return View();
        }
        [HttpPost]
        public JsonResult BMIView(BMI_Model person)
        {
            Calculate_BMI(person);
            ResultBox(person);
            return Json(person);
        }
        public void Calculate_BMI(BMI_Model person)
        {
            var height = person.Height / 100; //cmden metreye dönüştürme
            person.BMI = person.Weight / (height * height);
            
        }
        public void ResultBox(BMI_Model person) { 
            if (person.BMI < 18.5)
            {
                person.Result = "Under Weight";
            }
            else if (person.BMI >= 18.5 && person.BMI < 25)
            {
                person.Result = "Normal";
            }
            else if (person.BMI >= 25 && person.BMI < 30)
            {
                person.Result = "Over weight";
            }
            else if (person.BMI >= 30)
            {
                person.Result = "Obese";
            }
            
        }

        
    }
}
