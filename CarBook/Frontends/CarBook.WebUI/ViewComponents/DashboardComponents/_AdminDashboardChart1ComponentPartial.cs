using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardChart1ComponentPartial(IHttpClientFactory _httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7200/api/Cars/GetCarWithBrand");
            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var cars = JsonConvert.DeserializeObject<List<ResultCarDto>>(jsonData);
                var g1 = cars.Count(x => x.km <= 10000);
                var g2 = cars.Count(x => x.km > 10000 && x.km <= 20000);
                var g3 = cars.Count(x => x.km > 20000 && x.km <= 30000);
                var g4 = cars.Count(x => x.km > 30000 && x.km <= 40000);
                var g5 = cars.Count(x => x.km > 40000);

                ViewBag.KmLabels = new List<string> { "0-10 Bin", "10-20 Bin", "20-30 Bin", "30-40 Bin", "40 Bin+" };
                ViewBag.KmCounts = new List<int> { g1, g2, g3, g4, g5 };

                ViewBag.AvgKm = cars.Any() ? (int)cars.Average(x => x.km) : 0;
                ViewBag.MinKm = cars.Any() ? cars.Min(x => x.km) : 0;
            }
            return View();
        }
    }
}
