using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CellphoneStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShopManagerController : Controller
    {
        // GET: ShopManager
        public ActionResult Index()
        {
            return View();
        }

        // GET: ShopManager/CreateItem
        public ActionResult CreateItem()
        {
            return View();
        }

        // GET: ShopManager/Edit/5
        public ActionResult EditItem(int id)
        {
            ViewBag.id = id;
            return View();
        }

    }
}