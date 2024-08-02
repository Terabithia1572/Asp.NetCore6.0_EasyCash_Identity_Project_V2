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
                decimal result = decimal.Parse(jsonResponse["result"].ToString());
                string formattedResult = result.ToString("F2");

                // ViewBag'e result değerini ekle
                ViewBag.Exchange = formattedResult;
            }
            #region
            var client1 = new HttpClient();
            var request1 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=EUR&to=TRY&amount=1"),
                Headers =
        {
            { "x-rapidapi-key", "44a9b3ca28msh4dc1bc7bb828d5ap18c256jsn9125f1e0404c" },
            { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
        },
            };

            using (var response1 = await client.SendAsync(request1))
            {
                response1.EnsureSuccessStatusCode();
                var body = await response1.Content.ReadAsStringAsync();

                // JSON içeriğini ayrıştır
                var jsonResponse1 = JObject.Parse(body);

                // result kısmını al
                decimal result1 = decimal.Parse(jsonResponse1["result"].ToString());
                string formattedResult1 = result1.ToString("F2");

                // ViewBag'e result değerini ekle
                ViewBag.Exchange1 = formattedResult1;
            }
            #endregion,
            #region
            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=BTC&to=TRY&amount=1"),
                Headers =
        {
            { "x-rapidapi-key", "44a9b3ca28msh4dc1bc7bb828d5ap18c256jsn9125f1e0404c" },
            { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
        },
            };

            using (var response2 = await client.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body = await response2.Content.ReadAsStringAsync();

                // JSON içeriğini ayrıştır
                var jsonResponse2 = JObject.Parse(body);

                // result kısmını al
                decimal result2 = decimal.Parse(jsonResponse2["result"].ToString());
                string formattedResult2 = result2.ToString("F2");

                // ViewBag'e result değerini ekle
                ViewBag.Exchange2 = formattedResult2;
            }
            #endregion
            return View();
        }
    }
}
