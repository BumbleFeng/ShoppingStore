using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingStore.ViewComponents
{
    public class UserViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string username = await GetUsername();
            return View("Default", username);
        }

        private Task<string> GetUsername()
        {
            return Task.FromResult(HttpContext.Session.GetString("username"));
        }
    }
}
