using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShoppingStore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingStore.Controllers
{
    public class CartController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<HomeController> logger;

        public CartController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            string token = HttpContext.Session.GetString("token");
            IEnumerable<ShoppingCart> shoppingCarts = null;
            if (string.IsNullOrWhiteSpace(token))
            {
                return View(shoppingCarts);
            }
            string username = HttpContext.Session.GetString("username");
            StoreClient storeClient = new StoreClient(httpClientFactory.CreateClient());
            HttpResponseMessage result = storeClient.ShowCart(token);
            string s = result.Content.ReadAsStringAsync().Result;
            shoppingCarts = JsonConvert.DeserializeObject<IEnumerable<ShoppingCart>>(s);
            logger.LogInformation("User:" + username + " viewed cart");
            return View(shoppingCarts);
        }
    }
}
