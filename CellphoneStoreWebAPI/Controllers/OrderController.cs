using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CellphoneStoreWebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace CellphoneStoreWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Order")]
    public class OrderController : Controller
    {
        private CellphoneDbContext db;

        public OrderController(CellphoneDbContext db)
        {
            this.db = db;
        }
        // GET: api/Order
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Order/5
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Order
        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult CreateOrder([FromBody]CreateOrderForm obj)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(obj.OrderInfo);
                db.SaveChanges();
                var id = obj.OrderInfo.OrderID;

                foreach (var item in obj.ListDetailedOrder)
                {
                    item.OrderID = id;
                    item.TotalPrice = item.Quantity * item.Price;
                    db.DetailedOrders.Add(item);
                    db.SaveChanges();
                }
                return Ok();
            }
            return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList()); 
            
        }
    }
}
