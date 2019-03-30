using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShoppingStore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<HomeController> logger;

        public CategoryController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            string type = HttpContext.Request.Query["type"].ToString();
            StoreClient storeClient = new StoreClient(httpClientFactory.CreateClient());
            HttpResponseMessage result = storeClient.ItemList(type);
            string s = result.Content.ReadAsStringAsync().Result;
            IEnumerable<Item> items = JsonConvert.DeserializeObject<IEnumerable<Item>>(s);
            System.Diagnostics.Debug.WriteLine(items.Count());
            string username = HttpContext.Session.GetString("username");
            if (string.IsNullOrWhiteSpace(username))
            {
                if (string.IsNullOrWhiteSpace(type))
                    logger.LogInformation("User:" + username + " viewed all items");
                else
                    logger.LogInformation("User:" + username + " viewed category:" + type);
            }
            return View(items);
        }
    }
}
