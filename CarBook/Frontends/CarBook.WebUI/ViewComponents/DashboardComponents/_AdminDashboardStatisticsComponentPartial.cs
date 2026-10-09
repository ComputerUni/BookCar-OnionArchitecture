using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardStatisticsComponentPartial(IHttpClientFactory _httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();

            var responseCar = await client.GetAsync("https://localhost:7200/api/Statistics/GetCarCount");
            if (responseCar.IsSuccessStatusCode)
            {
                int rnd = random.Next(0, 101);
                ViewBag.randomCarCount = rnd;
                var jsonData = await responseCar.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.CarCount = values.CarCount;
            }

            var responseLocation = await client.GetAsync("https://localhost:7200/api/Statistics/GetLocationCount");
            if (responseLocation.IsSuccessStatusCode)
            {
                int rnd = random.Next(0, 101);
                ViewBag.randomLocationCount = rnd;
                var jsonData = await responseLocation.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.LocationCount = values.LocationCount;
            }

            var responseBrand = await client.GetAsync("https://localhost:7200/api/Statistics/GetBrandCount");
            if (responseBrand.IsSuccessStatusCode)
            {
                int rnd = random.Next(0, 101);
                ViewBag.randomBrandCount = rnd;
                var jsonData = await responseBrand.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.BrandCount = values.BrandCount;
            }

            var responseAvgRentPriceForDaily = await client.GetAsync("https://localhost:7200/api/Statistics/GetAvgRentPriceForDaily");
            if (responseAvgRentPriceForDaily.IsSuccessStatusCode)
            {
                int rnd = random.Next(0, 101);
                ViewBag.randomAvgRentPriceForDaily = rnd;
                var jsonData = await responseAvgRentPriceForDaily.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.AvgRentPriceForDaily = values.AvgRentPriceForDaily;
            }


            return View();
        }
    }
}
