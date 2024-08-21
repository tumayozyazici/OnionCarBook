﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnionCarBook.Dto.CommentDtos;

namespace OnionCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminComment")]
    public class AdminCommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("CommentListByBlogId/{id}")]
        public async Task<IActionResult> CommentListByBlogId(int id)
        {
            ViewBag.Id = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7126/api/Comments/GetCommentsByBlogID?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentByBlogIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
