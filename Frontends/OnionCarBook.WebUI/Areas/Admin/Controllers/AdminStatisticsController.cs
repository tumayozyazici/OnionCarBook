using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OnionCarBook.Dto.AuthorDtos;
using OnionCarBook.Dto.StatisticDtos;

namespace OnionCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var carCount = await GetCount("https://localhost:7126/api/Statistics/GetCarCount");
            var blogCount = await GetCount("https://localhost:7126/api/Statistics/GetBlogCount");
            var authorCount = await GetCount("https://localhost:7126/api/Statistics/GetAuthorCount");
            var locationCount = await GetCount("https://localhost:7126/api/Statistics/GetLocationCount");
            var brandCount = await GetCount("https://localhost:7126/api/Statistics/GetBrandCount");
            var automaticCarCount = await GetCount("https://localhost:7126/api/Statistics/GetCountOfAutomaticCars");
            var below1000KmCarCount = await GetCount("https://localhost:7126/api/Statistics/GetCarCountBelow1000Km");
            var gasolineorDieselCarCount = await GetCount("https://localhost:7126/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
            var electricCarCount = await GetCount("https://localhost:7126/api/Statistics/GetCarCountByFuelElectric");
            var dailyRentPriceAvg = await GetPrice("https://localhost:7126/api/Statistics/GetAvgRentPriceForDaily");
            var weeklyRentPriceAvg = await GetPrice("https://localhost:7126/api/Statistics/GetAvgRentPriceForWeekly");
            var monthlyRentPriceAvg = await GetPrice("https://localhost:7126/api/Statistics/GetAvgRentPriceForMonthly");
            var brandByCount = await GetName("https://localhost:7126/api/Statistics/GetBrandByMaxCarCount");
            var blogByComment = await GetName("https://localhost:7126/api/Statistics/GetBlogByMaxBlogComment");
            var brandModelMaxDailyPrice = await GetName("https://localhost:7126/api/Statistics/GetCarBrandAndModelByMaxRentPriceDaily");
            var brandModelMinDailyPrice = await GetName("https://localhost:7126/api/Statistics/GetCarBrandAndModelByMinRentPriceDaily");

            var values = new StatisticsTotalDto
            {
                CarCount = carCount,
                BlogCount = blogCount,
                AuthorCount = authorCount,
                LocationCount = locationCount,
                BrandCount = brandCount,
                AtomaticCarCount = automaticCarCount,
                Below1000KmCarCount = below1000KmCarCount,
                BlogByComment = blogByComment,
                BrandByCount = brandByCount,
                BrandModelMaxDailyPrice = brandModelMaxDailyPrice,
                BrandModelMinDailyPrice = brandModelMinDailyPrice,
                DailyRentPriceAvg = dailyRentPriceAvg,
                ElectricCarCount = electricCarCount,
                GasolineAndDieselCarCount = gasolineorDieselCarCount,
                MonthlyRentPriceAvg = monthlyRentPriceAvg,
                WeeklyRentPriceAvg = weeklyRentPriceAvg
            };
            return View(values);
        }

        private async Task<ResultStatisticCountDto> GetCount(string apiUrl)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{apiUrl}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<dynamic>(jsonData);
                var count = (int)((JObject)values).Properties().First().Value;
                return new ResultStatisticCountDto { Count = count };
            }
            return null;
        }

        private async Task<ResultStatisticPriceDto> GetPrice(string apiUrl)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{apiUrl}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<dynamic>(jsonData);
                var price = (decimal)((JObject)values).Properties().First().Value;
                return new ResultStatisticPriceDto { Price = price.ToString("0.00") };
            }
            return null;
        }
        private async Task<ResultStatisticNameDto> GetName(string apiUrl)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{apiUrl}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<dynamic>(jsonData);
                var name = (string)((JObject)values).Properties().First().Value;
                return new ResultStatisticNameDto { Name = name };
            }
            return null;
        }
    }
}
