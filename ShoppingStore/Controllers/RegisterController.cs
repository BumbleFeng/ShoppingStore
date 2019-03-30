using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingStore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingStore.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<HomeController> logger;

        public RegisterController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
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
            HttpStatusCode result = storeClient.Register(user);
            if (result == HttpStatusCode.Created)
            {
                logger.LogInformation("User:" + username + " registered");
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            logger.LogError("User:" + username + " register failed:" + result);
            return View();
        }
    }


}
