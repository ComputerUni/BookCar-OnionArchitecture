using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial(IHttpClientFactory _httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var responseCar = await client.GetAsync("https://localhost:7200/api/Statistics/GetCarCount");
            if (responseCar.IsSuccessStatusCode)
            {
                var jsonData = await responseCar.Content.ReadAsStringAsync();
                var valuesCar = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.carCount = valuesCar.CarCount;
            }


            var responseLocation = await client.GetAsync("https://localhost:7200/api/Statistics/GetLocationCount");
            if (responseLocation.IsSuccessStatusCode)
            {
                var jsonData = await responseLocation.Content.ReadAsStringAsync();
                var valuesLocation = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.locationCount = valuesLocation.LocationCount;
            }

            var responseBrand = await client.GetAsync("https://localhost:7200/api/Statistics/GetBrandCount");
            if (responseBrand.IsSuccessStatusCode)
            {
                var jsonData = await responseBrand.Content.ReadAsStringAsync();
                var valuesBrand = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.brandCount = valuesBrand.BrandCount;
            }

            var responseElectric = await client.GetAsync("https://localhost:7200/api/Statistics/GetCarCountByFuelElectric");
            if (responseElectric.IsSuccessStatusCode)
            {
                var jsonData = await responseBrand.Content.ReadAsStringAsync();
                var valuesElectric = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.electricCount = valuesElectric.CarCountByFuelElectric;
            }

            return View();
        }
    }
}
