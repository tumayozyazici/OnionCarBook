using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnionCarBook.Dto.BlogDtos;
using OnionCarBook.Dto.CarFeatureDtos;
using OnionCarBook.Dto.CategoryDtos;
using OnionCarBook.Dto.FeatureDtos;
using System.Net.Http;
using System.Text;

namespace OnionCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index/{id}")]
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7126/api/CarFeatures?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("Index/{id}")]
        [HttpPost]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDto)
        {
            var client = _httpClientFactory.CreateClient();
            foreach (var item in resultCarFeatureByCarIdDto)
            {
                if (item.Available) await client.GetAsync($"https://localhost:7126/api/CarFeatures/CarFeatureChangeAvailableToTrue?id={item.CarFeatureID}");
                else await client.GetAsync($"https://localhost:7126/api/CarFeatures/CarFeatureChangeAvailableToFalse?id={item.CarFeatureID}");
            }
            return RedirectToAction(nameof(Index), "AdminCar");
        }

        [Route("CreateFeatureByCarId")]
        [HttpGet]
        public async Task<IActionResult> CreateFeatureByCarId()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7126/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}