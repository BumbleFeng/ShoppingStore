using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace ShoppingStore.Models
{
    public class StoreClient
    {
        private readonly string HostUri;
        private readonly HttpClient Client;

        public StoreClient(HttpClient client)
        {
            HostUri = "https://shoppingstoreapi.azurewebsites.net";
            Client = client;
        }

        public HttpStatusCode Register(User user)
        {
            Client.BaseAddress = new Uri(new Uri(HostUri), "api/user/Register");
            HttpResponseMessage response = null;
            try
            {
                var output = JsonConvert.SerializeObject(user);
                HttpContent contentPost = new StringContent(output, System.Text.Encoding.UTF8, "application/json");
                response = Client.PostAsync(Client.BaseAddress, contentPost).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response.StatusCode;
        }

        public HttpResponseMessage Login(User user)
        {
            Client.BaseAddress = new Uri(new Uri(HostUri), "api/user/Login");
            HttpResponseMessage response = null;
            try
            {
                var output = JsonConvert.SerializeObject(user);
                HttpContent contentPost = new StringContent(output, System.Text.Encoding.UTF8, "application/json");
                response = Client.PostAsync(Client.BaseAddress, contentPost).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }

        public HttpStatusCode Logout(string token)
        {
            Client.BaseAddress = new Uri(new Uri(HostUri), "api/user/Logout?token="+token);
            HttpResponseMessage response = null;
            try
            {
                response = Client.GetAsync(Client.BaseAddress).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response.StatusCode;
        }

        public HttpResponseMessage Item(int id)
        {
            Client.BaseAddress = new Uri(new Uri(HostUri), "api/Item/"+id);
            HttpResponseMessage response = null;
            try
            {
                response = Client.GetAsync(Client.BaseAddress).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }

        public HttpResponseMessage ItemList(string type)
        {
            Client.BaseAddress = new Uri(new Uri(HostUri), "api/Item?type=" + type);
            HttpResponseMessage response = null;
            try
            {
                response = Client.GetAsync(Client.BaseAddress).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }

        public HttpResponseMessage AddCart(string token, ShoppingCart shoppingCart)
        {
            Client.BaseAddress = new Uri(new Uri(HostUri), "api/user/AddCart?token="+token);
            HttpResponseMessage response = null;
            try
            {
                var output = JsonConvert.SerializeObject(shoppingCart);
                System.Diagnostics.Debug.WriteLine(output);
                HttpContent contentPost = new StringContent(output, System.Text.Encoding.UTF8, "application/json");
                response = Client.PostAsync(Client.BaseAddress, contentPost).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }

        public HttpResponseMessage UpdateCart(string token, ShoppingCart shoppingCart)
        {
            Client.BaseAddress = new Uri(new Uri(HostUri), "api/user/UpdateCart?token=" + token);
            HttpResponseMessage response = null;
            try
            {
                var output = JsonConvert.SerializeObject(shoppingCart);
                System.Diagnostics.Debug.WriteLine(output);
                HttpContent contentPost = new StringContent(output, System.Text.Encoding.UTF8, "application/json");
                response = Client.PutAsync(Client.BaseAddress, contentPost).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }

        public HttpResponseMessage ShowCart(string token)
        {
            Client.BaseAddress = new Uri(new Uri(HostUri), "api/user/ShowCart?token=" + token);
            HttpResponseMessage response = null;
            try
            {
                response = Client.GetAsync(Client.BaseAddress).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }

        public HttpResponseMessage PlaceOrder(string token)
        {
            Client.BaseAddress = new Uri(new Uri(HostUri), "api/user/PlaceOrder?token=" + token);
            HttpResponseMessage response = null;
            try
            {
                response = Client.GetAsync(Client.BaseAddress).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }

        public HttpResponseMessage Checkout(string token, OrderDetail orderDetail, string same)
        {
            Client.BaseAddress = new Uri(new Uri(HostUri), "api/user/Checkout?token=" + token + "&same=" + same);
            HttpResponseMessage response = null;
            try
            {
                var output = JsonConvert.SerializeObject(orderDetail);
                System.Diagnostics.Debug.WriteLine(output);
                HttpContent contentPost = new StringContent(output, System.Text.Encoding.UTF8, "application/json");
                response = Client.PostAsync(Client.BaseAddress, contentPost).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }

        public HttpResponseMessage OrderList(string token)
        {
            Client.BaseAddress = new Uri(new Uri(HostUri), "api/user/OrderList?token=" + token);
            HttpResponseMessage response = null;
            try
            {
                response = Client.GetAsync(Client.BaseAddress).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }

        public HttpResponseMessage OrderDetail(string token, string orderId)
        {
            Client.BaseAddress = new Uri(new Uri(HostUri), "api/user/OrderDetail/" + orderId + "?token=" + token);
            HttpResponseMessage response = null;
            try
            {
                response = Client.GetAsync(Client.BaseAddress).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }

        public HttpStatusCode Error()
        {
            Client.BaseAddress = new Uri(new Uri(HostUri), "api/error");
            HttpResponseMessage response = null;
            try
            {
                response = Client.GetAsync(Client.BaseAddress).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response.StatusCode;
        }

    }
}
