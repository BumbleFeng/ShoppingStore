using System;
using System.Collections.Generic;
using System.Linq;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreAPI.Controllers
{
    public class UserController : Controller
    {

        private readonly StoreDbContext db;
        const string secret = "INFO6250";


        public UserController(StoreDbContext db)
        {
            this.db = db;
        }

        public User FindUser(string username)
        {
            return db.Users.FirstOrDefault(_ => _.Username == username);
        }

        [HttpGet]
        [Route("api/[controller]/[action]")]
        [ActionName("Token")]
        public IActionResult Token()
        {
            string token = RequestToken("abc");
            return new OkObjectResult(token); 
        }

        [HttpPost]
        [Route("api/[controller]/[action]")]
        [ActionName("Register")]
        public IActionResult Register([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return new BadRequestResult();

            User u = FindUser(user.Username);
            if (u != null)
            {
                return new ConflictResult();
            }
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            db.Users.Add(user);
            db.SaveChanges();
            return new CreatedResult("id", FindUser(user.Username).UserId); //created
        }

        [HttpPost]
        [Route("api/[controller]/[action]")]
        [ActionName("Login")]
        public IActionResult Login([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return new BadRequestResult();
            User u = FindUser(user.Username);
            if (u != null && BCrypt.Net.BCrypt.Verify(user.Password, u.Password))
            {
                string token = RequestToken(user.Username);
                return new OkObjectResult(token); //created
            }
            return new UnauthorizedResult();
        }

        private string RequestToken(string username)
        {
            User user = FindUser(username);
            var token = new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(secret)
                .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
                .AddClaim("userid", user.UserId)
                .Build();
            user.Token = token;
            db.SaveChanges();
            return token;
        }

        [HttpGet]
        [Route("api/[controller]/[action]")]
        [ActionName("Logout")]
        public IActionResult Logout()
        {
            string token = HttpContext.Request.Query["token"].ToString();
            User user = Authorize(token);
            if (user == null)
                return new UnauthorizedResult();
            user.Token = null;
            db.SaveChanges();
            return new OkResult();
        }

        [HttpPost]
        [Route("api/[controller]/[action]")]
        [ActionName("AddCart")]
        public IActionResult AddCart([FromBody] ShoppingCart shoppingCart)
        {
            if (!ModelState.IsValid)
                return new BadRequestResult();
            string token = HttpContext.Request.Query["token"].ToString();
            User user = Authorize(token);
            if (user == null)
                return new UnauthorizedResult();
            Item item = db.Items.FirstOrDefault(_ => _.ItemId == shoppingCart.ItemId);
            if (shoppingCart.Number > item.Stock)
                return new BadRequestResult();
            ShoppingCart sc = db.ShoppingCarts.FirstOrDefault(_ => _.UserId == user.UserId && _.ItemId == shoppingCart.ItemId);
            if (sc != null)
            {
                if (sc.Number + shoppingCart.Number > item.Stock)
                    return new BadRequestResult();
                sc.Number += shoppingCart.Number;
            }
            else
            {
                if (shoppingCart.Number != 0)
                {
                    shoppingCart.UserId = user.UserId;
                    shoppingCart.AddTime = DateTime.Now;
                    db.ShoppingCarts.Add(shoppingCart);
                }
                else
                    return new BadRequestResult();
            }
            db.SaveChanges();
            string newToken = RequestToken(user.Username);
            return new OkObjectResult(newToken);
        }

        [HttpPut]
        [Route("api/[controller]/[action]")]
        [ActionName("UpdateCart")]
        public IActionResult UpdateCart([FromBody] ShoppingCart shoppingCart)
        {
            if (!ModelState.IsValid)
                return new BadRequestResult();
            string token = HttpContext.Request.Query["token"].ToString();
            User user = Authorize(token);
            if (user == null)
                return new UnauthorizedResult();
            Item item = db.Items.FirstOrDefault(_ => _.ItemId == shoppingCart.ItemId);
            if (shoppingCart.Number > item.Stock)
                return new BadRequestResult();
            ShoppingCart sc = db.ShoppingCarts.FirstOrDefault(_ => _.UserId == user.UserId && _.ItemId == shoppingCart.ItemId);
            if (sc != null)
            {
                if (shoppingCart.Number != 0)
                    sc.Number = shoppingCart.Number;
                else
                    db.ShoppingCarts.Remove(sc);
            }
            else
            {
                return new BadRequestResult();
            }
            db.SaveChanges();
            string newToken = RequestToken(user.Username);
            return new OkObjectResult(newToken);
        }

        [HttpGet]
        [Route("api/[controller]/[action]")]
        [ActionName("ShowCart")]
        public IActionResult ShowCart()
        {
            if (!ModelState.IsValid)
                return new BadRequestResult();
            string token = HttpContext.Request.Query["token"].ToString();
            User user = Authorize(token);
            if (user == null)
                return new UnauthorizedResult();
            List<ShoppingCart> shoppingCarts = CheckStock(user);
            return new OkObjectResult(shoppingCarts);
        }

        [HttpGet]
        [Route("api/[controller]/[action]")]
        [ActionName("PlaceOrder")]
        public IActionResult PlaceOrder()
        {
            if (!ModelState.IsValid)
                return new BadRequestResult();
            string token = HttpContext.Request.Query["token"].ToString();
            User user = Authorize(token);
            if (user == null)
                return new UnauthorizedResult();
            List<ShoppingCart> shoppingCarts = CheckStock(user);
            if (shoppingCarts.Count == 0 || shoppingCarts.Any(_ => _.Number == 0))
                return new BadRequestResult();
            List<Payment> payments = db.Payments.Where(_ => _.UserId == user.UserId).ToList();
            payments.ForEach(_ => _.CardNumber = "************" + _.CardNumber.Substring(12));
            User u = new User
            {
                ShoppingCarts = shoppingCarts,
                Addresses = db.Addresses.Where(_ => _.UserId == user.UserId).ToList(),
                Payments = payments,
                Token = RequestToken(user.Username)
            };
            return new OkObjectResult(u);
        }

        [HttpPost]
        [Route("api/[controller]/[action]")]
        [ActionName("Checkout")]
        public IActionResult Checkout([FromBody] OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
                return new BadRequestResult();
            string token = HttpContext.Request.Query["token"].ToString();
            string same = HttpContext.Request.Query["same"].ToString();
            User user = Authorize(token);
            if (user == null)
                return new UnauthorizedResult();
            orderDetail.UserId = user.UserId;

            Address address;
            if (orderDetail.ShippingAddressId != 0)
            {
                address = db.Addresses.FirstOrDefault(_ => _.AddressId == orderDetail.ShippingAddressId);
                if (address == null || address.UserId != user.UserId)
                    return new UnauthorizedResult();
            }
            else if (orderDetail.ShippingAddress != null)
            {
                address = orderDetail.ShippingAddress;
                address.UserId = user.UserId;
                db.Addresses.Add(address);
                db.SaveChanges();
            }
            else
                return new BadRequestResult();
            orderDetail.ShippingAddressId = address.AddressId;

            Payment payment;
            if (orderDetail.PaymentId != 0)
            {
                payment = db.Payments.FirstOrDefault(_ => _.PaymentId == orderDetail.PaymentId);
                if (payment == null || payment.UserId != user.UserId)
                    return new UnauthorizedResult();
            }
            else if (orderDetail.Payment != null)
            {
                payment = orderDetail.Payment;
                payment.BillingAddressId = address.AddressId;
                if (same.Equals("F") && payment.BillingAddress != null)
                {
                    Address billingAddress = payment.BillingAddress;
                    billingAddress.UserId = user.UserId;
                    db.Addresses.Add(billingAddress);
                    db.SaveChanges();
                    payment.BillingAddressId = billingAddress.AddressId;
                }
                payment.UserId = user.UserId;
                db.Payments.Add(payment);
                db.SaveChanges();
            }
            else
                return new BadRequestResult();
            orderDetail.PaymentId = payment.PaymentId;

            string orderid;
            DateTime now;
            do
            {
                now = DateTime.Now;
                Random random = new Random();
                int r = random.Next(1000, 9999);
                orderid = now.ToString("yyyyMMddHHmmssfffffff") + r.ToString();
            } while (db.OrderDetails.FirstOrDefault(_ => _.OrderId == orderid) != null);
            orderDetail.OrderId = orderid;
            orderDetail.PlacedTime = now;
            List<ShoppingCart> shoppingCarts = CheckStock(user);
            if (shoppingCarts.Count == 0 || shoppingCarts.Any(_ => _.Number == 0))
                return new BadRequestResult();
            double total = 0.0;
            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (ShoppingCart shoppingCart in shoppingCarts)
            {
                Item item = db.Items.FirstOrDefault(_ => _.ItemId == shoppingCart.ItemId);
                if (shoppingCart.Number > item.Stock)
                    return new BadRequestResult();
                item.Stock -= shoppingCart.Number;
                total += item.Price * shoppingCart.Number;
                OrderItem orderItem = new OrderItem
                {
                    OrderId = orderid,
                    ItemId = item.ItemId,
                    Number = shoppingCart.Number
                };
                orderItems.Add(orderItem);
                db.ShoppingCarts.Remove(shoppingCart);
            }
            db.SaveChanges();
            orderDetail.Total = total;
            orderDetail.Staus = "Placed";
            db.OrderDetails.Add(orderDetail);
            db.SaveChanges();
            orderItems.ForEach(_ => db.OrderItems.Add(_));
            db.SaveChanges();
            return new OkObjectResult(orderDetail.OrderId);
        }

        [HttpGet]
        [Route("api/[controller]/[action]")]
        [ActionName("OrderList")]
        public IActionResult OrderList()
        {
            string token = HttpContext.Request.Query["token"].ToString();
            User user = Authorize(token);
            if (user == null)
                return new UnauthorizedResult();
            List<OrderDetail> orderDetails = db.OrderDetails.Where(_ => _.UserId == user.UserId).ToList();
            orderDetails.ForEach(_ => _.User = null);
            return new OkObjectResult(orderDetails);
        }

        [HttpGet]
        [Route("api/[controller]/[action]/{OrderId}")]
        [ActionName("OrderDetail")]
        public IActionResult OrderDetail(string OrderId)
        {
            string token = HttpContext.Request.Query["token"].ToString();
            User user = Authorize(token);
            OrderDetail orderDetail = db.OrderDetails.FirstOrDefault(_ => _.OrderId == OrderId);
            if (orderDetail == null)
                return new NotFoundResult();
            if (user == null || orderDetail.UserId != user.UserId)
                return new UnauthorizedResult();
            User u = new User
            {
                Token = RequestToken(user.Username)
            };
            orderDetail.User = u;
            List<OrderItem> orderItems = db.OrderItems.Where(_ => _.OrderId == OrderId).ToList();
            orderItems.ForEach(_ => _.Item = db.Items.FirstOrDefault(i => i.ItemId == _.ItemId));
            orderDetail.OrderItems = orderItems;
            orderDetail.ShippingAddress = db.Addresses.FirstOrDefault(_ => _.AddressId == orderDetail.ShippingAddressId);
            orderDetail.Payment = db.Payments.FirstOrDefault(_ => _.PaymentId == orderDetail.PaymentId);
            orderDetail.Payment.CardNumber = orderDetail.Payment.CardNumber.Substring(12);
            orderDetail.Payment.CVV = null;
            orderDetail.Payment.BillingAddress = db.Addresses.FirstOrDefault(_ => _.AddressId == orderDetail.Payment.BillingAddressId);
            return new OkObjectResult(orderDetail);
        }

        public User Authorize(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return null;

            try
            {
                var payload = new JwtBuilder()
                    .WithSecret(secret)
                    .MustVerifySignature()
                    .Decode<IDictionary<string, object>>(token);
            }
            catch (TokenExpiredException)
            {
                return null;
            }
            catch (SignatureVerificationException)
            {
                return null;
            }
            return db.Users.FirstOrDefault(_ => _.Token == token);
        }

        public List<ShoppingCart> CheckStock(User user)
        {
            List<ShoppingCart> shoppingCarts = db.ShoppingCarts.Where(_ => _.UserId == user.UserId).ToList();
            foreach (ShoppingCart shoppingCart in shoppingCarts)
            {
                Item item = db.Items.FirstOrDefault(_ => _.ItemId == shoppingCart.ItemId);
                if (shoppingCart.Number > item.Stock)
                {
                    shoppingCart.Number = item.Stock;
                }
            }
            db.SaveChanges();
            return shoppingCarts;
        }
    }
}
