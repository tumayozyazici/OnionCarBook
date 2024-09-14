using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace OnionCarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardChart2ComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _AdminDashboardChart2ComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
