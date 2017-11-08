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

        // GET: ShopManager/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.id = id;
            return View();
        }

        // GET: ShopManager/CreateItem
        public ActionResult CreateItem()
        {
            return View();
        }
        // GET: ShopManager/CreateBrand
        public ActionResult CreateBrand()
        {
            return View();
        }

        // GET: ShopManager/Edit/5
        public ActionResult EditItem(int id)
        {
            ViewBag.id = id;
            return View();
        }

        //// POST: ShopManager/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ShopManager/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: ShopManager/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}