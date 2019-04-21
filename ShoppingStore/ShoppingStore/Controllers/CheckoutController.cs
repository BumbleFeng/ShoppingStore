using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShoppingStore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingStore.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<HomeController> logger;

        public CheckoutController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            string token = HttpContext.Session.GetString("token");
            if (string.IsNullOrWhiteSpace(token))
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            string username = HttpContext.Session.GetString("username");
            StoreClient storeClient = new StoreClient(httpClientFactory.CreateClient());
            HttpResponseMessage result = storeClient.PlaceOrder(token);
            if (result.IsSuccessStatusCode)
            {
                string s = result.Content.ReadAsStringAsync().Result;
                User user = JsonConvert.DeserializeObject<User>(s);
                HttpContext.Session.SetString("token", user.Password);
                logger.LogInformation("User:" + username + " checkout");
                return View(user);
            }
            logger.LogError("User:" + username + " checkout failed:" + result.StatusCode);
            return RedirectToRoute(new { controller = "Cart", action = "Index" });
        }
    }
}
