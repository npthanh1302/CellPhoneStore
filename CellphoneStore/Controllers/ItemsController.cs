using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using CellphoneStore.Models;

namespace CellphoneStore.Controllers
{
    public class ItemsController : Controller
    {
        // GET: Items
        public ActionResult Index()
        {
            return View();
        }

        // GET: Items/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.id = id;
            return View();
        }



    }
}