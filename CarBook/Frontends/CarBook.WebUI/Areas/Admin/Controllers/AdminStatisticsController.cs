using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController(IHttpClientFactory _httpClientFactory) : Controller
    {
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();

            var responseCar = await client.GetAsync("https://localhost:7200/api/Statistics/GetCarCount");
            if(responseCar.IsSuccessStatusCode)
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

            var responseAuthor = await client.GetAsync("https://localhost:7200/api/Statistics/GetAuthorCount");
            if (responseAuthor.IsSuccessStatusCode)
            {
                int rnd = random.Next(0, 101);
                ViewBag.randomAuthorCount = rnd;
                var jsonData = await responseAuthor.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.AuthorCount = values.AuthorCount;
            }

            var responseBlog = await client.GetAsync("https://localhost:7200/api/Statistics/GetBlogCount");
            if (responseBlog.IsSuccessStatusCode)
            {
                int rnd = random.Next(0, 101);
                ViewBag.randomBlogCount = rnd;
                var jsonData = await responseBlog.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.BlogCount = values.BlogCount;
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

            var responseAvgRentPriceForWeekly = await client.GetAsync("https://localhost:7200/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseAvgRentPriceForWeekly.IsSuccessStatusCode)
            {
                int rnd = random.Next(0, 101);
                ViewBag.randomAvgRentPriceForWeekly = rnd;
                var jsonData = await responseAvgRentPriceForWeekly.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.AvgRentPriceForWeekly = values.AvgRentPriceForWeekly;
            }

            var responseAvgRentPriceForMonthly = await client.GetAsync("https://localhost:7200/api/Statistics/GetAvgRentPriceForMonthly");
            if (responseAvgRentPriceForMonthly.IsSuccessStatusCode)
            {
                int rnd = random.Next(0, 101);
                ViewBag.randomAvgRentPriceForMonthly = rnd;
                var jsonData = await responseAvgRentPriceForMonthly.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.AvgRentPriceForMonthly = values.AvgRentPriceForMonthly;
            }

            var responseCarCountByTransmissionIsAuto = await client.GetAsync("https://localhost:7200/api/Statistics/GetCarCountByTransmissionIsAuto");
            if (responseCarCountByTransmissionIsAuto.IsSuccessStatusCode)
            {
                int rnd = random.Next(0, 101);
                ViewBag.randomCarCountByTransmissionIsAuto = rnd;
                var jsonData = await responseCarCountByTransmissionIsAuto.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.CarCountByTransmissionIsAuto = values.CarCountByTransmissionIsAuto;
            }

            var responseBrandNameByMaxCar = await client.GetAsync("https://localhost:7200/api/Statistics/GetBrandNameByMaxCar");
            if (responseBrandNameByMaxCar.IsSuccessStatusCode)
            {
                int rnd = random.Next(0, 101);
                ViewBag.randomBrandNameByMaxCar = rnd;
                var jsonData = await responseBrandNameByMaxCar.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.BrandNameByMaxCar = values.BrandNameByMaxCar;
            }

            var responseBlogTitleByMaxBlogComment = await client.GetAsync("https://localhost:7200/api/Statistics/GetBlogTitleByMaxBlogComment");
            if (responseBlogTitleByMaxBlogComment.IsSuccessStatusCode)
            {
                int rnd = random.Next(0, 101);
                ViewBag.randomBlogTitleByMaxBlogComment = rnd;
                var jsonData = await responseBlogTitleByMaxBlogComment.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.BlogTitleByMaxBlogComment = values.BlogTitleByMaxBlogComment;
            }

            var responseCarCountByKmSmallerThen1000 = await client.GetAsync("https://localhost:7200/api/Statistics/GetCarCountByKmSmallerThen1000");
            if (responseCarCountByKmSmallerThen1000.IsSuccessStatusCode)
            {
                int rnd = random.Next(0, 101);
                ViewBag.randomCarCountByKmSmallerThen1000 = rnd;
                var jsonData = await responseCarCountByKmSmallerThen1000.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.CarCountByKmSmallerThen1000 = values.CarCountByKmSmallerThen1000;
            }

            var responseCarCountByFuelGasolineOrDiesel = await client.GetAsync("https://localhost:7200/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
            if (responseCarCountByFuelGasolineOrDiesel.IsSuccessStatusCode)
            {
                int rnd = random.Next(0, 101);
                ViewBag.randomCarCountByFuelGasolineOrDiesel = rnd;
                var jsonData = await responseCarCountByFuelGasolineOrDiesel.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.CarCountByFuelGasolineOrDiesel = values.CarCountByFuelGasolineOrDiesel;
            }

            var responseCarCountByFuelElectric = await client.GetAsync("https://localhost:7200/api/Statistics/GetCarCountByFuelElectric");
            if (responseCarCountByFuelElectric.IsSuccessStatusCode)
            {
                int rnd = random.Next(0, 101);
                ViewBag.randomCarCountByFuelElectric = rnd;
                var jsonData = await responseCarCountByFuelElectric.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.CarCountByFuelElectric = values.CarCountByFuelElectric;
            }

            var responseCarBrandAndModelByRentPriceDailyMax = await client.GetAsync("https://localhost:7200/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");
            if (responseCarBrandAndModelByRentPriceDailyMax.IsSuccessStatusCode)
            {
                int rnd = random.Next(0, 101);
                ViewBag.randomCarBrandAndModelByRentPriceDailyMax = rnd;
                var jsonData = await responseCarBrandAndModelByRentPriceDailyMax.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.CarBrandAndModelByRentPriceDailyMax = values.CarBrandAndModelByRentPriceDailyMax;
            }

            var responseCarBrandAndModelByRentPriceDailyMin = await client.GetAsync("https://localhost:7200/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");
            if (responseCarBrandAndModelByRentPriceDailyMin.IsSuccessStatusCode)
            {
                int rnd = random.Next(0, 101);
                ViewBag.randomCarBrandAndModelByRentPriceDailyMin = rnd;
                var jsonData = await responseCarBrandAndModelByRentPriceDailyMin.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.CarBrandAndModelByRentPriceDailyMin = values.CarBrandAndModelByRentPriceDailyMin;
            }

            return View();
        }
    }
}
