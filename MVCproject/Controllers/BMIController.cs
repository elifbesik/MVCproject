using Microsoft.AspNetCore.Mvc;
using MVCproject.Models;

namespace MVCproject.Controllers
{
    public class BMIController : Controller
    {
        //ViewResult : response olarak bir view dosyasını render etmemizi sağlayan action trüdür.

        //PartialViewResult:
        //yine bir View dosyasını render etmemizi sağlar.
        //ama bunu farkı client tabanlı yapılan ajax isteklerinde kullanıma daha uygundur.
        //ajaxta sunucuda bir değer üretiriz ve bu değeri cliennt tabanlı ilgili alana yazdırırız.
        //sayfa yenielenmeden yapılan işlelerdir. burada PartialView kullanmak daha uygundur.
        //teknik bir fark olarak viewresult view doaysını baz alır partial iste dosyadaki belirli bir bölgeyi baz alarak render eder.


        //JsonResult:
        //üretilen datayı JSON türüne dönüştürüp döndüren bir action türüdür.
        // JSON bir javasctipt metinsel nesnesidir.json javascript dili içerisindeki JavaScript nesne sabit metinlerini,
        //dizilerini ve skaler verilerini temsil eden metin tabanlı bir yöntemdir. 


        //EmptyResult:
        //bazen gelen istekler sonuzunda herhangi bir şey döndüremk istemsezek bu action türü kullanılabilir.
        // geriye boş bir result döndürmek hiçbir şey döndürmemek demek değildir. response bvardır ama result yoktur bölece empty olmuş olur.


        //ContentResult:iste sonucunda cevap oolarak metinsel bri değer döndürmemizi sağlauan action türüdür.sayfanın formatını sonucu text olarak gönderir. 


        //ActionResult:
        //bütün action türlerinin base clasııdır . gelenn bir istek sonucunda geriye döndürülecek action türleri değişkenlik gösterebildiği durumşarda kullanılam nit aftion türüfür.
        //bütün bu action türlerinim atasıdır


        //IActionResult: actşon resultun bir interfaveidir.


        //[NonAction]:
        //eğer bir fonksiyon conroller içeirisnde sadece iş yapan algoritma barındıran metodlara non action tagi verilerek aviton olmadığını belirtirriz
        // bu attrirbute ile işaretlenen fonksiyonlar dışarıdanr equest karşılamazlar.


        //[NonController]: dışarıdan request almasını istemiyorsak etiketleriz. sıradan bir sınıfs dönüşmüş olur.

        [HttpGet]
        public IActionResult BMIView() // controller sınıflarının içerisindeki yapılacak işlre göre oluşturulmuş fonksiyonlar actionlardır.
        {
            return View();
        }
       
        public JsonResult BMIView(BMI_Model person)
        {
            Calculate_BMI(person);
            ResultBox(person);
            return Json(person);
        }
        public IActionResult Toplama(BMI_Model person)
        {
            var toplam = person.Height+ person.Weight;
            ViewBag.toplam= toplam; // viewvbag; viewe taşınacak datayı diamik şekilde tanımlanabilri bir ddeğişkenle
                                    // taşımamızı sağlayan bir veri taşıma kontrolüdür. 
            return View("BMIView"); // belirtilen view ismindeki view dosyaısını render eder
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
