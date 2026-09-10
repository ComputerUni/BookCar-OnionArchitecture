using CarBook.Dto.CarDtos;
using CarBook.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class CarController(IHttpClientFactory _httpClientFactory) : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Araçlarımız";
            ViewBag.v2 = "Size En Uygun Olanı Seçiniz";
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7200/api/CarPricings/");
            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
