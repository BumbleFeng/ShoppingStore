using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ShoppingStore.Models;
using Microsoft.Extensions.Logging;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingStore.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<HomeController> logger;

        public LoginController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return View();
            User user = new User
            {
                Username = username,
                Password = password
            };
            StoreClient storeClient = new StoreClient(httpClientFactory.CreateClient());
            HttpResponseMessage result = storeClient.Login(user);
            if (result.IsSuccessStatusCode)
            {
                HttpContext.Session.SetString("token", result.Content.ReadAsStringAsync().Result);
                HttpContext.Session.SetString("username", username);
                logger.LogInformation("User:" + username + " login");
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            logger.LogError("User:" + username + " login failed: " + result.StatusCode);
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            string username = HttpContext.Session.GetString("username");
            HttpContext.Session.Clear();
            logger.LogInformation("User:" + username + " logout");
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }
    }
}
