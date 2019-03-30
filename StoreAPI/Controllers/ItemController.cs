using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreAPI.Controllers
{
    public class ItemController : Controller
    {
        private readonly StoreDbContext db;

        public ItemController(StoreDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            string type = HttpContext.Request.Query["type"].ToString();
            List<Item> items = new List<Item>(); 
            if(string.IsNullOrWhiteSpace(type))
                items = db.Items.ToList();
            else
                items = db.Items.Where(_ => string.Compare(_.Type, type, true) == 0 ).ToList();
            return new OkObjectResult(items);
        }

        [HttpGet]
        [Route("api/[controller]/{ItemId}")]
        public IActionResult Get(int ItemId)
        {
            Item item = db.Items.FirstOrDefault(_ => _.ItemId == ItemId);
            if (item == null)
                return new NotFoundResult();
            else
                return new OkObjectResult(item);
        }
    }
}
