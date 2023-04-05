using Microsoft.AspNetCore.Mvc;
using MVCproject.Models;
using Newtonsoft.Json;

// temp data ile bir actiondan başka bir action metoduna veri taşımak için kullanılır 
//contollerlar uygulamaya gelen istekleri karşılayabilmek için kullandığımız sınıflardır.,

namespace MVCproject.Controllers
{
    public class RandomQuoteController : Controller
    {
        //controller sınıfları içerisinde istekleri karşılayan methodlara action denir.
        //controller sınıfları içeriinde tanımlanan tüm metotlar action olarak nitelendirlir.

        //action metodlarının viewda bir kaşılıkları vardır. ama başka veri tipleri de dönebiliriz. ajaxta jsonresult ile json veri tipi döneriz
         
        public IActionResult RandomQuoteView()//
        {
            return View(); //controllerın cliente bilgiyi response etmesi yani view dosyasını render etmesidir. 
            //view fonksiyonu bu actiona ait view dosyasını tetikleyecek olan fonksiyondur.

        }

        [HttpGet] 
        //httpget : http protokollerinden verileri almak veya listelemek için kullanılanırdır.
        //server(sunucu) ve clientın(istemci) birbiri ile haberleşmesini sağlmak için kullanırı.

        //
        public JsonResult Api() 
        {
             
            List<QuoteModel> quotes = new List<QuoteModel>();
            string Url = "https://zenquotes.io/api/quotes";


            //
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(Url).Result;

            if( response.IsSuccessStatusCode)
            {
                quotes = JsonConvert.DeserializeObject<List<QuoteModel>>(response.Content.ReadAsStringAsync().Result);
            }
            //deserializeobject:

            //async:


            //listenin uzunluğunu alma ve random number olarak json döndürme
            int listLength = quotes.Count();
            int randomNumber = CreateRandomNumber(listLength);

            return Json(quotes[randomNumber]);
        }
        //json javascript dili içerisindeki JavaScript nesne sabit metinlerini,
        //dizilerini ve skaler verilerini temsil eden metin tabanlı bir yöntemdir. 

        public int CreateRandomNumber (int n) 
        {   
            Random randomNumber = new Random();
            int number =randomNumber.Next(n);
            return number;
        }

    }
}
