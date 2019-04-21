using System;
using System.Globalization;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShoppingStore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingStore.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<HomeController> logger;

        public OrderDetailController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public IActionResult Index(string id)
        {
            string token = HttpContext.Session.GetString("token");
            if (string.IsNullOrWhiteSpace(token))
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            string username = HttpContext.Session.GetString("username");
            StoreClient storeClient = new StoreClient(httpClientFactory.CreateClient());
            HttpResponseMessage result = storeClient.OrderDetail(token, id);
            if (result.IsSuccessStatusCode)
            {
                string s = result.Content.ReadAsStringAsync().Result;
                OrderDetail orderDetail = JsonConvert.DeserializeObject<OrderDetail>(s);
                HttpContext.Session.SetString("token", orderDetail.User.Password);
                logger.LogInformation("User:" + username + " viewed order:" + id);
                return View(orderDetail);
            }
            logger.LogError("Order:" + id + " not found for user:" + username);
            return new NotFoundResult();
        }

        [HttpPost]
        public IActionResult Index()
        {
            string token = HttpContext.Session.GetString("token");
            if (string.IsNullOrWhiteSpace(token))
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            string username = HttpContext.Session.GetString("username");
            OrderDetail orderDetail = new OrderDetail
            {
                ShippingAddressId = Int32.Parse(HttpContext.Request.Form["savedAddress"]),
                PaymentId = Int32.Parse(HttpContext.Request.Form["savedCards"])
            };
            string same = HttpContext.Request.Form["billingAsShipping"];
            if (orderDetail.ShippingAddressId == 0)
            {
                Address shippingAddress = new Address
                {
                    FirstName = HttpContext.Request.Form["shippingFirstname"],
                    LastName = HttpContext.Request.Form["shippingLastname"],
                    Phone = HttpContext.Request.Form["shippingPhone"],
                    Address1 = HttpContext.Request.Form["shippingAddress1"],
                    Address2 = HttpContext.Request.Form["shippingAddress2"],
                    City = HttpContext.Request.Form["shippingCity"],
                    State = HttpContext.Request.Form["shippingState"],
                    Zip = HttpContext.Request.Form["shippingZip"]
                };
                orderDetail.ShippingAddress = shippingAddress;
            }
            if (orderDetail.PaymentId == 0)
            {
                Payment payment = new Payment
                {
                    NameOnCard = HttpContext.Request.Form["nameOnCard"],
                    CardType = HttpContext.Request.Form["paymentMethod"],
                    CardNumber = HttpContext.Request.Form["cardNumber"],
                    Expiration = DateTime.ParseExact(HttpContext.Request.Form["expire"], "yyyy-MM", CultureInfo.InvariantCulture).ToString("MMyy"),
                    CVV = HttpContext.Request.Form["cvv"]
                };
                if (same == null)
                {
                    same = "F";
                    Address billingAddress = new Address
                    {
                        FirstName = HttpContext.Request.Form["billingFirstname"],
                        LastName = HttpContext.Request.Form["billingLastname"],
                        Address1 = HttpContext.Request.Form["billingAddress1"],
                        Address2 = HttpContext.Request.Form["billingAddress2"],
                        City = HttpContext.Request.Form["billingCity"],
                        State = HttpContext.Request.Form["billingState"],
                        Zip = HttpContext.Request.Form["billingZip"]
                    };
                    payment.BillingAddress = billingAddress;
                }
                orderDetail.Payment = payment;
            }
            if (orderDetail.VerifyOrder() != "valid")
            {
                logger.LogError("Verify order:" + JsonConvert.SerializeObject(orderDetail) + " failed: " + orderDetail.VerifyOrder());
                return RedirectToRoute(new { controller = "Checkout", action = "Index" });
            }
            StoreClient storeClient = new StoreClient(httpClientFactory.CreateClient());
            HttpResponseMessage result = storeClient.Checkout(token, orderDetail, same);
            if (result.IsSuccessStatusCode)
            {
                string OrderId = result.Content.ReadAsStringAsync().Result;
                logger.LogInformation("User:" + username + " plaeced order: " + OrderId);
                return Index(OrderId);
            }
            logger.LogInformation("User:" + username + "plaeced order: " + JsonConvert.SerializeObject(orderDetail) + " failed");
            return RedirectToRoute(new { controller = "Checkout", action = "Index" });
        }
    }
}
