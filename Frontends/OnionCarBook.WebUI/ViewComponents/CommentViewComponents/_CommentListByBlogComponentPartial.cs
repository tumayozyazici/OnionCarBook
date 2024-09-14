using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnionCarBook.Dto.CommentDtos;
using OnionCarBook.Dto.TagCloudDtos;

namespace OnionCarBook.WebUI.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogComponentPartial :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CommentListByBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.blogid = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7126/api/Comments/GetCommentsByBlogID?id={id}");
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
