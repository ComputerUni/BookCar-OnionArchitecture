using CarBook.Dto.CarFeatureDtos;
using CarBook.Dto.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController(IHttpClientFactory _httpClientFactory) : Controller
    {

        [Route("Index/{id}")]
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7200/api/CarFeatures/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                return View(value);
            }
            return View();
        }

        [Route("Index/{id}")]
        [HttpPost]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDto)
        {
            foreach (var item in resultCarFeatureByCarIdDto)
            {
                if (item.Available)
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync($"https://localhost:7200/api/CarFeatures/CarFeatureChangeAvailableToTrue?id=/{item.CarFeatureId}");
                }
                else
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync($"https://localhost:7200/api/CarFeatures/CarFeatureChangeAvailableToFalse?id=/{item.CarFeatureId}");
                }
            }
            return RedirectToAction("Index", "AdminCar");
        }
    }
}
