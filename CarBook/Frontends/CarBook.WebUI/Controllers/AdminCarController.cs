using CarBook.Domain.Enums;
using CarBook.Dto.BrandDtos;
using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using X.PagedList.Extensions;

namespace CarBook.WebUI.Controllers
{
    public class AdminCarController(IHttpClientFactory _httpClientFactory) : Controller
    {
        public async Task<IActionResult> Index(int page = 1)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7200/api/Cars/GetCarWithBrand");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultCarDto>>(jsonData);
                return View(value.ToPagedList(page, 13));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateCar() 
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7200/api/Brands");

            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
            List<SelectListItem> brandValues = (from x in value
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.BrandId.ToString()
                                                }).ToList();
            ViewBag.BrandValues = brandValues;

            List<SelectListItem> transmissionTypes = (from TransmissionType item in Enum.GetValues(typeof(TransmissionType))
                                                      select new SelectListItem
                                                      {
                                                          Text = item.ToString(),
                                                          Value = ((int)item).ToString()
                                                      }).ToList();

            ViewBag.TransmissionValues = transmissionTypes;

            List<SelectListItem> fuelTypes = (from FuelType item in Enum.GetValues(typeof(FuelType))
                                              select new SelectListItem
                                              {
                                                  Text = item.ToString(),
                                                  Value = ((int)item).ToString()
                                              }).ToList();

            ViewBag.FuelValues = fuelTypes;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCarDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7200/api/Cars", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> RemoveCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7200/api/Cars/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var brandResponse = await client.GetAsync("https://localhost:7200/api/Brands");
            if (brandResponse.IsSuccessStatusCode)
            {
                var brandJson = await brandResponse.Content.ReadAsStringAsync();
                var brands = JsonConvert.DeserializeObject<List<ResultBrandDto>>(brandJson);
                List<SelectListItem> brandValues = (from x in brands
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.BrandId.ToString()
                                                    }).ToList();
                ViewBag.BrandValues = brandValues;
            }

            List<SelectListItem> transmissionTypes = (from TransmissionType item in Enum.GetValues(typeof(TransmissionType))
                                                      select new SelectListItem
                                                      {
                                                          Text = item.ToString(),
                                                          Value = ((int)item).ToString()
                                                      }).ToList();

            ViewBag.TransmissionValues = transmissionTypes;

            List<SelectListItem> fuelTypes = (from FuelType item in Enum.GetValues(typeof(FuelType))
                                              select new SelectListItem
                                              {
                                                  Text = item.ToString(),
                                                  Value = ((int)item).ToString()
                                              }).ToList();

            ViewBag.FuelValues = fuelTypes;


            var carResponse = await client.GetAsync($"https://localhost:7200/api/Cars/{id}");
            if (carResponse.IsSuccessStatusCode)
            {
                var carJson = await carResponse.Content.ReadAsStringAsync();
                var carValues = JsonConvert.DeserializeObject<UpdateCarDto>(carJson);
                return View(carValues);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCarDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7200/api/Cars", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return await UpdateCar(updateCarDto.CarId);
        }

    }
}
