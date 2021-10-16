using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CURDLearn1016.Models;

namespace CURDLearn1016.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetMyDataTable() {
            using (MyDataBaseEntities Mydb = new MyDataBaseEntities()) {
                var Data = Mydb.MyDataTable.OrderBy(m=>m.Id).ToList();
                return Json(new { data = Data }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Save(int id) {
            using (MyDataBaseEntities Mydb = new MyDataBaseEntities()) {
                var v = Mydb.MyDataTable.Where(m => m.Id == id).FirstOrDefault();
                return View(v);
            };
        }
        [HttpPost]
        public ActionResult Save(MyDataTable mydb)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (MyDataBaseEntities Mydb = new MyDataBaseEntities())
                {
                    if (mydb.Id > 0)
                    {
                        //Edit
                        var v = Mydb.MyDataTable.Where(m => m.Id == mydb.Id).FirstOrDefault();
                        if (v != null)
                        {
                            v.Name = mydb.Name;
                            v.Sex = mydb.Sex;
                            v.Age = mydb.Age;
                        }
                    }
                    else
                    {
                        Mydb.MyDataTable.Add(mydb);
                    }
                    Mydb.SaveChanges();
                    status = true;
                }
            }
            //return new JsonResult { Data = new { status = status } };
            return View("Index");
        }
        
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (MyDataBaseEntities Mydb = new MyDataBaseEntities())
            {
                var v = Mydb.MyDataTable.Where(m => m.Id == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteMyData(int id)
        {
            bool status = false;
            using (MyDataBaseEntities Mydb = new MyDataBaseEntities())
            {
                var v = Mydb.MyDataTable.Where(m => m.Id == id).FirstOrDefault();
                if (v != null)
                {
                    Mydb.MyDataTable.Remove(v);
                    Mydb.SaveChanges();
                    status = true;
                }
            }
            //return new JsonResult { Data = new { status = status } };
            return View("Index");
        }
    }
}
