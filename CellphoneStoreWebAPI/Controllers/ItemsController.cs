using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CellphoneStoreWebAPI.Models;

namespace CellphoneStoreWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private CellphoneDbContext db;

        public ItemsController(CellphoneDbContext db)
        {
            this.db = db;
        }
        //Get api/Items?brandid for items of a brand or api/Items for list of all items
        [HttpGet]
        public List<Item> GetItemsByBrand(int brandid)
        {
            if (brandid != 0)
                return db.Items.FromSql("SELECT * FROM dbo.Items WHERE ManufacturerID = " + brandid.ToString() ).ToList();
            return db.Items.ToList();
        }


        // GET api/Items/5 a specific item
        [HttpGet("{id}")]
        public Item Get(int id)
        {
            return db.Items.Find(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Item obj)
        {
           
                db.Items.Add(obj);
                db.SaveChanges();

                return new ObjectResult("Employee added successfully!");
       
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Item obj)
        {
            
                db.Entry<Item>(obj).State = EntityState.Modified;
                db.SaveChanges();

                return new ObjectResult("Employee modified successfully!");
          
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
         
                db.Items.Remove(db.Items.Find(id));
                db.SaveChanges();

                return new ObjectResult("Employee deleted successfully!");
         
        }
    }
}