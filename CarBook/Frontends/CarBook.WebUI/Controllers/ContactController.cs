using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class ContactController(IHttpClientFactory _httpClientFactory) : Controller
    {
        public async Task<IActionResult> Index()
        {
            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("https://localhost:7200/api/Contacts");
            //if(response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<ResultFooterAddressDto>(jsonData);
            //}
            return View();
        }
    }
}
