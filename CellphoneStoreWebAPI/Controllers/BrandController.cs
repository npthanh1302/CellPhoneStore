using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CellphoneStoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CellphoneStoreWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Brands")]
    public class BrandController : Controller
    {

        // GET api/Brands

        private CellphoneDbContext db;

        public BrandController(CellphoneDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public List<Brand> Get()
        {
            return db.Brands.ToList();
        }

        // GET api/Brands/5
        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            return db.Brands.Find(id);
        }


        // POST api/Brands
        [HttpPost]
        public IActionResult Post([FromBody]Brand obj)
        {
                db.Brands.Add(obj);
                db.SaveChanges();
            return new ObjectResult("Employee added successfully!");
        }

        // PUT api/Brands/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Brand obj)
        {

            db.Entry<Brand>(obj).State = EntityState.Modified;
            db.SaveChanges();

            return new ObjectResult("Employee modified successfully!");

        }

        // DELETE api/Brands/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            db.Brands.Remove(db.Brands.Find(id));
            db.SaveChanges();

            return new ObjectResult("Employee deleted successfully!");

        }
    }
    
}