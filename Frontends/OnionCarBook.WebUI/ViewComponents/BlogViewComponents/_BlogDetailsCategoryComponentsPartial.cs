﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnionCarBook.Dto.CategoryDtos;
using OnionCarBook.Dto.ServiceDtos;

namespace OnionCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsCategoryComponentsPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsCategoryComponentsPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7126/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
