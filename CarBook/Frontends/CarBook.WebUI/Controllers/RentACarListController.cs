using CarBook.Dto.BrandDtos;
using CarBook.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using X.PagedList.Extensions;

namespace CarBook.WebUI.Controllers
{
    public class RentACarListController(IHttpClientFactory _httpClientFactory) : Controller
    {
        public async Task<IActionResult> Index(int id)
        {
            var locationId = TempData["locationId"];
            id = int.Parse(locationId.ToString());
            ViewBag.locationId = locationId;

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7200/api/RentACars?locationId={id}&isAvailable=true");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
