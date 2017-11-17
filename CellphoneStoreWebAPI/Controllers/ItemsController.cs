using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CellphoneStoreWebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace CellphoneStoreWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Items")]
    
    public class ItemsController : Controller
    {
        private CellphoneDbContext db;

        public ItemsController (CellphoneDbContext db)
        {
            this.db = db;
        }
        //Get api/Items?brandid for items of a brand or api/Items for list of all items
        
        [HttpGet]
        public List<Item> GetItemsByBrand(int? brandid, string name, int? minPrice, int? maxPrice)
        {
            if (brandid == null && name == null && minPrice == null && maxPrice == null)
                return db.Items.FromSql("SELECT * FROM dbo.Items order by Price asc").ToList();
            else if (brandid == null && name == null && minPrice != null && maxPrice != null)
                return db.Items.FromSql("SELECT * FROM dbo.Items where Price between " + minPrice + " and " + maxPrice + " order by Price asc").ToList();
            else if (brandid != 0 && name == null && minPrice == null && maxPrice == null)//filter by brandid
                return db.Items.FromSql("SELECT * FROM dbo.Items WHERE ManufacturerID = " + brandid.ToString() + " order by Price asc").ToList();
            else if (brandid == null && name != null && minPrice == null && maxPrice == null)//filter by name (input search)
                return db.Items.FromSql("SELECT * FROM dbo.Items WHERE Name like " + "'%" + name.ToString() + "%'" + " order by Price asc").ToList();

            return db.Items.FromSql("SELECT * FROM dbo.Items order by Price asc").ToList();
        }


        // GET api/Items/5 a specific item
        [HttpGet("{id}")]
        public Item Get(int id)
        {
            return db.Items.Find(id);
        }

        //api/Item/BestSale
        [HttpGet("BestSale")]
        public List<Item> GetBestSale()
        {
            return db.Items.FromSql("select top 8 * from Items order by Price asc").ToList();
        }

        // GET: api/Item/Newest
        [HttpGet("Newest")]
        public List<Item> GetNewest()
        {
            return db.Items.FromSql("select top 8 * from Items order by CreatedDate desc").ToList();
        }


        // POST api/Items
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody]Item obj)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(obj);             
                db.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
        }

        // PUT api/Items/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(int id, [FromBody]Item obj)
        {
            if (ModelState.IsValid)
            {
                db.Entry<Item>(obj).State = EntityState.Modified;
                db.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
        }



        // DELETE api/Items/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
                db.Items.Remove(db.Items.Find(id));
                db.SaveChanges();
            return Ok();
        }
    }
}