using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using OnionCarBook.Dto.BrandDtos;
using OnionCarBook.Dto.RentACarDtos;
using System.Net.Http;
using System.Text;

namespace OnionCarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            
            var locationID = TempData["locationid"];
            ViewBag.locationid = locationID;

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7126/api/RentACars?locationID={Convert.ToInt32(locationID)}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRentACarDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
