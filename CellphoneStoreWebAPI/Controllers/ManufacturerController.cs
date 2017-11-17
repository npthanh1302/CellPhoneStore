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
    [Route("api/Manufacturers")]
    public class ManufacturerController : Controller
    {
        private CellphoneDbContext db;

        public ManufacturerController(CellphoneDbContext db)
        {
            this.db = db;
        }
        // GET api/Manufacturers
        [HttpGet]
        public List<Manufacturer> Get()
        {
            return db.Manufacturers.ToList();
        }

        // GET api/Manufacturers/5
        [HttpGet("{id}")]
        public Manufacturer Get(int id)
        {
            return db.Manufacturers.Find(id);
        }

    }
    
}