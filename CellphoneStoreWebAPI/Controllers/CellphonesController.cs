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
    [Route("api/Cellphones")]
    public class CellphonesController : Controller
    {

        //private readonly CellphoneDbContext _context;

        //public CellphonesController(CellphoneDbContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/Cellphones
        //[HttpGet]
        //public IEnumerable<Cellphone> GetCellphones()
        //{
        //    return _context.Cellphones;
        //}

        //// GET: api/Cellphones/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetCellphone([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var cellphone = await _context.Cellphones.SingleOrDefaultAsync(m => m.ItemID == id);

        //    if (cellphone == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(cellphone);
        //}

        //// PUT: api/Cellphones/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCellphone([FromRoute] int id, [FromBody] Cellphone cellphone)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != cellphone.ItemID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(cellphone).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CellphoneExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Cellphones
        //[HttpPost]
        //public async Task<IActionResult> PostCellphone([FromBody] Cellphone cellphone)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Cellphones.Add(cellphone);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCellphone", new { id = cellphone.ItemID }, cellphone);
        //}

        //// DELETE: api/Cellphones/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCellphone([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var cellphone = await _context.Cellphones.SingleOrDefaultAsync(m => m.ItemID == id);
        //    if (cellphone == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Cellphones.Remove(cellphone);
        //    await _context.SaveChangesAsync();

        //    return Ok(cellphone);
        //}

        //private bool CellphoneExists(int id)
        //{
        //    return _context.Cellphones.Any(e => e.ItemID == id);
        //}

        // GET api/values

        private CellphoneDbContext db;

        public CellphonesController(CellphoneDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public List<Cellphone> Get()
        {
           
            return db.Cellphones.ToList();
     
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Cellphone Get(int id)
        {
           
                return db.Cellphones.Find(id);
          
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Cellphone obj)
        {
           
                db.Cellphones.Add(obj);
                db.SaveChanges();

                return new ObjectResult("Employee added successfully!");
       
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Cellphone obj)
        {
            
                db.Entry<Cellphone>(obj).State = EntityState.Modified;
                db.SaveChanges();

                return new ObjectResult("Employee modified successfully!");
          
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
         
                db.Cellphones.Remove(db.Cellphones.Find(id));
                db.SaveChanges();

                return new ObjectResult("Employee deleted successfully!");
         
        }
    }
}