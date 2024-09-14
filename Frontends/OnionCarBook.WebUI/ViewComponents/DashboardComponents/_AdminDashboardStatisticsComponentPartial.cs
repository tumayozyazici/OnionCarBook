using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using OnionCarBook.Dto.StatisticDtos;

namespace OnionCarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var locationCount = await GetCount("https://localhost:7126/api/Statistics/GetLocationCount");
            var brandCount = await GetCount("https://localhost:7126/api/Statistics/GetBrandCount");
            var dailyRentPriceAvg = await GetPrice("https://localhost:7126/api/Statistics/GetAvgRentPriceForDaily");
            var carCount = await GetCount("https://localhost:7126/api/Statistics/GetCarCount");

            ViewBag.LocationCount = locationCount;
            ViewBag.BrandCount = brandCount;
            ViewBag.CarCount = carCount;
            ViewBag.DailyRentPriceAvg = dailyRentPriceAvg;

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
                return count;
            }
            return 0;
        }

        private async Task<string> GetPrice(string apiUrl)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{apiUrl}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<dynamic>(jsonData);
                var price = (decimal)((JObject)values).Properties().First().Value;
                return price.ToString("0.00");
            }
            return "";
        }
    }
}
