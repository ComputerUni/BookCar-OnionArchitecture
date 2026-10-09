using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardChart3ComponentPartial(IHttpClientFactory _httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7200/api/Blogs/GetAllBlogsWithAuthors");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var blogs = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthors>>(jsonData);

                var categoriesCount = blogs.GroupBy(x => x.CategoryName).Select(g => new { CategoryName = g.Key, Count = g.Count() })
                                            .OrderByDescending(x => x.Count).ToList();

                ViewBag.BlogLabels = categoriesCount.Select(x => x.CategoryName).ToList();
                ViewBag.BlogCounts = categoriesCount.Select(x => x.Count).ToList();

                ViewBag.TotalBlogCount = blogs.Count;
                ViewBag.TotalCategoryCount = categoriesCount.Count;
            }       
            return View();
        }
    }
}
