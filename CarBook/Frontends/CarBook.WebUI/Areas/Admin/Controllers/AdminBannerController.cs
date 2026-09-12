using CarBook.Dto.BannerDtos;
using CarBook.Dto.BrandDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminBanner")]
    public class AdminBannerController(IHttpClientFactory _httpClientFactory) : Controller
    {
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7200/api/Banners");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateBanner")]
        public async Task<IActionResult> CreateBanner()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateBanner")]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBannerDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7200/api/Banners", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBanner", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateBanner/{id}")]
        public async Task<IActionResult> UpdateBanner(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7200/api/Banners/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBannerDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateBanner/{id?}")]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBannerDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7200/api/Banners", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBanner", new { area = "Admin" });
            }
            return View(updateBannerDto);
        }


        [Route("RemoveBanner/{id}")]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7200/api/Banners/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBanner", new { area = "Admin" });
            }

            return RedirectToAction("Index", "AdminBanner", new { area = "Admin" });
        }

    }
}
