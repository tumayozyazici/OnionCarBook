﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnionCarBook.Dto.CarDtos;

namespace OnionCarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Araçlarımız";
            ViewBag.v2 = "Aracınızı Seçiniz";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7126/api/Cars/GetCarWithBrand");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
