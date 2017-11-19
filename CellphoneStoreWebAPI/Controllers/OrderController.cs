using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CellphoneStoreWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using CellphoneStoreWebAPI.Models.OrderModel;
using Microsoft.EntityFrameworkCore;

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
        public List<Order> Get()
        {
            return db.Orders.ToList();
        }

        // GET: api/Order/5
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}", Name = "Get")]
        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        //GET: api/Order/Details/
        [HttpGet("details/{id}")]
        [Authorize(Roles = "Admin")]
        public List<OrderDetailView> GetOrderDetailView(int id)
        {
            List<OrderDetailView> result = new List<OrderDetailView>();

            var test = db.DetailedOrders
                .Join(db.Items,
                    d => d.ItemID,
                    i => i.ItemID,
                    (d, i) => new
                    {
                        OrderID = d.OrderID,
                        ItemName = i.Name,
                        Price = d.Price,
                        Quantity = d.Quantity,
                    }).
                Where(a => a.OrderID == id).ToList();
            foreach (var item in test)
            {
                result.Add(new OrderDetailView(item.OrderID, item.ItemName,item.Price,item.Quantity));
            }
            return result;
        }
        // POST: api/Order
        [HttpPost]
        [Authorize(Roles = "Admin,User")]
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
                return new ObjectResult(obj.OrderInfo.OrderID);
            }
            return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList()); 
            
        }
    }
}
