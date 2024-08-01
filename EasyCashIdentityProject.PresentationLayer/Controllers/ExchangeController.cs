using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=USD&to=TRY&amount=1"),
                Headers =
        {
            { "x-rapidapi-key", "44a9b3ca28msh4dc1bc7bb828d5ap18c256jsn9125f1e0404c" },
            { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
        },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                // JSON içeriğini ayrıştır
                var jsonResponse = JObject.Parse(body);

                // result kısmını al
                var result = jsonResponse["result"].ToString();

                // ViewBag'e result değerini ekle
                ViewBag.Exchange = result;
            }
            return View();
        }
    }
}
