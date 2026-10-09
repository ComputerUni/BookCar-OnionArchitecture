using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardChart2ComponentPartial(IHttpClientFactory _httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7200/api/Cars/GetCarWithBrand");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var cars = JsonConvert.DeserializeObject<List<ResultCarDto>>(jsonData);

                var brandCounts = cars.GroupBy(x => x.brandName).Select(g => new { BrandName = g.Key, Count = g.Count() })
                                      .OrderByDescending(x => x.Count).ToList();

                ViewBag.BrandLabels = brandCounts.Select(x => x.BrandName).ToList();
                ViewBag.BrandCounts = brandCounts.Select(x => x.Count).ToList();

                ViewBag.TotalCarCount = cars.Count;
                ViewBag.TotalBrandCount = brandCounts.Count;
            }
            return View();
        }
    }
}
