using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    public class AdminCarFeatureDetailController(IHttpClientFactory _httpClientFactory) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AdminCarDetail(int id)
        {
            return View();
        }
    }
}
