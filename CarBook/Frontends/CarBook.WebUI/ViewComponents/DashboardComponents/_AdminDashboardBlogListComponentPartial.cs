using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardBlogListComponentPartial(IHttpClientFactory _httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7200/api/Blogs/GetAllBlogsWithAuthors");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthors>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
