using CarBook.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList.Extensions;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminComment")]
    public class AdminCommentController(IHttpClientFactory _httpClientFactory) : Controller
    {
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id, int page = 1)
        {
            ViewBag.v = id;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7200/api/Comments/CommentListByBlog?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                return View(values.ToPagedList(page, 12));
            }
            return View();
        }

    }
}
