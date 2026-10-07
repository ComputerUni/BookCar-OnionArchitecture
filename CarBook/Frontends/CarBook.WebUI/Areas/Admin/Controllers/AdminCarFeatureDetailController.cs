using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController(IHttpClientFactory _httpClientFactory) : Controller
    {

        [Route("Index/{id}")]
        public IActionResult Index(int id)
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult AdminCarDetail(int id)
        //{
        //    return View();
        //}
    }
}
