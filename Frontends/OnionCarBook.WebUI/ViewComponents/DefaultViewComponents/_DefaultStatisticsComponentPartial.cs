using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using OnionCarBook.Dto.StatisticDtos;
using System.Net.Http;

namespace OnionCarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var carCount = await GetCount("https://localhost:7126/api/Statistics/GetCarCount");
            var locationCount = await GetCount("https://localhost:7126/api/Statistics/GetLocationCount");
            var brandCount = await GetCount("https://localhost:7126/api/Statistics/GetBrandCount");
            var electricCarCount = await GetCount("https://localhost:7126/api/Statistics/GetCarCountByFuelElectric");

            ViewBag.CarCount = carCount;
            ViewBag.LocationCount = locationCount;
            ViewBag.BrandCount = brandCount;
            ViewBag.ElectricCarCount = electricCarCount;
            return View();
        }

        private async Task<int> GetCount(string apiUrl)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{apiUrl}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<dynamic>(jsonData);
                var count = (int)((JObject)values).Properties().First().Value;
                return count ;
            }
            return 0;
        }
    }
}