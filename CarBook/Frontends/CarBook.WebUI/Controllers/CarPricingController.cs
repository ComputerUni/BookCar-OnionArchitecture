using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class CarPricingController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Paketlerimiz";
            ViewBag.v2 = "Araç Fiyat Paketlerimiz";
            return View();
        }
    }
}
