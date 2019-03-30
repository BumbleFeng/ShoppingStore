using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingStore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingStore.Controllers
{

    public class OrderController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public OrderController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("[controller]")]
        public IActionResult Index()
        {
            string token = HttpContext.Session.GetString("token");
            if (string.IsNullOrWhiteSpace(token))
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            StoreClient storeClient = new StoreClient(httpClientFactory.CreateClient());
            HttpResponseMessage result = storeClient.OrderList(token);
            string s = result.Content.ReadAsStringAsync().Result;
            IEnumerable<OrderDetail> orderDetails = JsonConvert.DeserializeObject<IEnumerable<OrderDetail>>(s);
            return new OkObjectResult(orderDetails);
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public IActionResult Order(string id)
        {
            string token = HttpContext.Session.GetString("token");
            if (string.IsNullOrWhiteSpace(token))
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            StoreClient storeClient = new StoreClient(httpClientFactory.CreateClient());
            HttpResponseMessage result = storeClient.OrderDetail(token, id);
            if (result.IsSuccessStatusCode)
            {
                string s = result.Content.ReadAsStringAsync().Result;
                OrderDetail orderDetail = JsonConvert.DeserializeObject<OrderDetail>(s);
                return new OkObjectResult(orderDetail);
            }
            else
            {
                return new NotFoundResult();
            }
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        [ActionName("PlaceOrder")]
        public IActionResult PlaceOrder()
        {
            string token = HttpContext.Session.GetString("token");
            if (string.IsNullOrWhiteSpace(token))
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            StoreClient storeClient = new StoreClient(httpClientFactory.CreateClient());
            HttpResponseMessage result = storeClient.PlaceOrder(token);
            if (result.IsSuccessStatusCode)
            {
                string s = result.Content.ReadAsStringAsync().Result;
                User user = JsonConvert.DeserializeObject<User>(s);
                return new OkObjectResult(user);
            }
            else 
            {
                return RedirectToRoute(new { controller = "Cart", action = "Index" });
            }
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        [ActionName("Checkout")]
        public IActionResult Checkout()
        {
            string token = HttpContext.Session.GetString("token");
            string same = HttpContext.Request.Query["same"].ToString();
            if (string.IsNullOrWhiteSpace(token))
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            OrderDetail orderDetail = new OrderDetail
            {
                //ShippingAddressId = 3,
                //PaymentId = 1
            };
            Address shippingAddress = new Address
            {
                FirstName = "James",
                LastName = "Yu",
                Address1 = "123 abc ave",
                City = "Boston",
                State = "MA",
                Zip = "02115",
                Phone = "8118881234"
            };
            orderDetail.ShippingAddress = shippingAddress;
            Payment payment = new Payment
            {
                NameOnCard = "James",
                CardType = "Credit",
                CardNumber = "1234567812345678",
                Expiration = "1221",
                CVV = "123"
            };
            if (same.Equals("F"))
            {
                Address billingAddress = new Address
                {
                    FirstName = "James",
                    LastName = "Yu",
                    Address1 = "321 abc ave",
                    City = "Boston",
                    State = "MA",
                    Zip = "02115",
                    Phone = "4325431234"
                };
                payment.BillingAddress = billingAddress;
            }
            orderDetail.Payment = payment;
            if (!orderDetail.VerifyOrder())
                return RedirectToRoute(new { controller = "Order", action = "PlaceOrder" });
            StoreClient storeClient = new StoreClient(httpClientFactory.CreateClient());
            HttpResponseMessage result = storeClient.Checkout(token, orderDetail, same);
            if (result.IsSuccessStatusCode)
            {
                string s = result.Content.ReadAsStringAsync().Result;
                OrderDetail od = JsonConvert.DeserializeObject<OrderDetail>(s);
                return View(od);
            }
            else
                return RedirectToRoute(new { controller = "Order", action = "PlaceOrder" });
        }

    }
}
