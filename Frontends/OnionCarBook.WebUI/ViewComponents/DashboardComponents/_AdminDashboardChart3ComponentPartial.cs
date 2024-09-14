using Microsoft.AspNetCore.Mvc;

namespace OnionCarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardChart3ComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _AdminDashboardChart3ComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
