using CarBook.Dto.CarDtos;
using CarBook.Dto.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailMainCarFeatureComponentPartial(IHttpClientFactory _httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.carid = id;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7200/api/Cars/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCarDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
