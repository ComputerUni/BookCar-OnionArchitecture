using CarBook.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardCarPricingListComponentPartial(IHttpClientFactory _httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.v1 = "Paketlerimiz";
            ViewBag.v2 = "Araç Fiyat Paketlerimiz";
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7200/api/CarPricings/GetCarPricingWithTimePeriod");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingListWithModelDto>>(jsonData);
                var limitedValues = values.Take(8).ToList();
                return View(limitedValues);
            }
            return View();
        }
    }
}
