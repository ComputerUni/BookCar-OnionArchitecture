using CarBook.Dto.LoginDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class LoginController(IHttpClientFactory _httpClientFactory) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginAppUserDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            return View();
        }
    }
}
