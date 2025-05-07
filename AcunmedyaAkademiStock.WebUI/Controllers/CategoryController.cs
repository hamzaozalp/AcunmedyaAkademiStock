using AcunmedyaAkademiStock.WebUI.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AcunmedyaAkademiStock.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> CategoryList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7104/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
            
            }

            [HttpGet]

            public IActionResult CreateCategory()
            {
                return View();
            }

            [HttpPost]

             public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
            {
                var client= _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createCategoryDto);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                await client.PostAsync("https://localhost:7104/api/Categories", content);
                return RedirectToAction("CategoryList");
            }

            public async Task<IActionResult> DeleteCategory(int id)
            {
                var client = _httpClientFactory.CreateClient();
                await client.DeleteAsync("https://localhost:7104/api/Categories?id" + id);
                return RedirectToAction("CategoryList");
            }
    }

}
