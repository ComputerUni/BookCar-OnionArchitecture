using CarBook.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList.Extensions;

namespace CarBook.WebUI.Controllers
{
    public class CarPricingController(IHttpClientFactory _httpClientFactory) : Controller
    {
        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.v1 = "Paketlerimiz";
            ViewBag.v2 = "Araç Fiyat Paketlerimiz";
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7200/api/CarPricings/GetCarPricingWithTimePeriod");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingListWithModelDto>>(jsonData);
                return View(values.ToPagedList(page, 8));
            }
            return View();
        }
    }
}
