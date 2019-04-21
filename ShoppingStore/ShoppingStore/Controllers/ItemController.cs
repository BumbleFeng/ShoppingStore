using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShoppingStore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingStore.Controllers
{
    public class ItemController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<HomeController> logger;

        public ItemController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public IActionResult Index(int id)
        {
            StoreClient storeClient = new StoreClient(httpClientFactory.CreateClient());
            HttpResponseMessage result = storeClient.Item(id);
            if (result.IsSuccessStatusCode)
            {
                string s = result.Content.ReadAsStringAsync().Result;
                Item item = JsonConvert.DeserializeObject<Item>(s);
                string username = HttpContext.Session.GetString("username");
                if (!string.IsNullOrWhiteSpace(username))
                {
                    logger.LogInformation("User:" + username + " viewed item:" + id + " " + item.Name);
                }
                return View(item);
            }
            logger.LogError("item:" + id + " not found");
            return new NotFoundResult();
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        [ActionName("AddCart")]
        public string AddCart(int itemId, int number)
        {
            string token = HttpContext.Session.GetString("token");
            if (string.IsNullOrWhiteSpace(token))
            {
                return "Please Login First";
            }
            string username = HttpContext.Session.GetString("username");
            ShoppingCart shoppingCart = new ShoppingCart
            {
                ItemId = itemId,
                Number = number
            };
            StoreClient storeClient = new StoreClient(httpClientFactory.CreateClient());
            HttpResponseMessage result = storeClient.AddCart(token, shoppingCart);
            if (result.IsSuccessStatusCode)
            {
                HttpContext.Session.SetString("token", result.Content.ReadAsStringAsync().Result);
                logger.LogInformation("User:" + username + " add item:" + itemId + " with number:" + number + " to cart");
                return "Add Success";
            }
            if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                logger.LogError("User:" + username + " add item:" + itemId + " with number:" + number + " failed:out of stock");
                return "Out of Stock";
            }
            logger.LogError("User:" + username + " add item:" + itemId + " with number:" + number + " failed:" + result.StatusCode);
            return "Error";
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        [ActionName("UpdateCart")]
        public string UpdateCart(int itemId, int number)
        {
            string token = HttpContext.Session.GetString("token");
            if (string.IsNullOrWhiteSpace(token))
            {
                return "Please Login First";
            }
            string username = HttpContext.Session.GetString("username");
            ShoppingCart shoppingCart = new ShoppingCart
            {
                ItemId = itemId,
                Number = number
            };
            StoreClient storeClient = new StoreClient(httpClientFactory.CreateClient());
            HttpResponseMessage result = storeClient.UpdateCart(token, shoppingCart);
            if (result.IsSuccessStatusCode)
            {
                HttpContext.Session.SetString("token", result.Content.ReadAsStringAsync().Result);
                if (shoppingCart.Number == 0)
                {
                    logger.LogInformation("User:" + username + " delete item:" + itemId + " from cart");
                    return "Delete Success";
                }
                logger.LogInformation("User:" + username + " update item:" + itemId + " with number:" + number);
                return "Success";
            }
            if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                logger.LogError("User:" + username + " update item:" + itemId + " with number:" + number + " failed:out of stock");
                return "Out of Stock";
            }
            logger.LogError("User:" + username + " update item:" + itemId + " with number:" + number + " failed:" + result.StatusCode);
            return "Error";
        }
    }
}
