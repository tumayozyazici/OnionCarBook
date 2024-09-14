using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnionCarBook.Dto.BlogDtos;

namespace OnionCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsMainComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsMainComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage1 = await client.GetAsync($"https://localhost:7126/api/Comments/GetCommentCountByBlogID?id={id}");
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage1.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<int>(jsonData);
                ViewBag.CommentCount = values;
            }

            var responseMessage = await client.GetAsync($"https://localhost:7126/api/Blogs/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetBlogById>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
