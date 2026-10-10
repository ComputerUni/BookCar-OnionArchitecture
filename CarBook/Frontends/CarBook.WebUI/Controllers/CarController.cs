using CarBook.Dto.CarDtos;
using CarBook.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList.Extensions;

namespace CarBook.WebUI.Controllers
{
    public class CarController(IHttpClientFactory _httpClientFactory) : Controller
    {
        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.v1 = "Araçlarımız";
            ViewBag.v2 = "Size En Uygun Olanı Seçiniz";
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7200/api/CarPricings/");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarDto>>(jsonData);
                return View(values.ToPagedList(page, 9));
            }
            return View();
        }

        public async Task<IActionResult> CarDetail(int id)
        {
            ViewBag.v1 = "Araç Detayları";
            ViewBag.v2 = "Aracın Teknik ve Aksesuar Özellikleri";
            ViewBag.carid = id;
            return View();
        }
    }
}
