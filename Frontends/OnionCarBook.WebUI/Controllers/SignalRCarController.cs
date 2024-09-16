using Microsoft.AspNetCore.Mvc;

namespace OnionCarBook.WebUI.Controllers
{
    public class SignalRCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
