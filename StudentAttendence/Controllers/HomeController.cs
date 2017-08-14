using StudentAttendence.Models;
using StudentAttendenceSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentAttendence.Controllers
{
    public class HomeController : Controller
    {
        public StudentManagmentSystem db = new StudentManagmentSystem();

        // GET: Home
        public ActionResult Index()
        {

            var bat = new Class1();
            bat.lab = db.Batches.Select(x=>new SelectListItem {Value=x.Id.ToString(),Text=x.BatchCode }).ToList();

           //var batch = db.Batches.ToList();
            
           // ViewBag.batch = new SelectList(list,"id","BatchCode");




            return View(bat);
        }
        

        [HttpPost]
        [HttpGet]
        public ActionResult Index(string batchcode, string StudentName, string atten, string date, StudentAtten att)
        {

            att.BatchCode = batchcode;
            att.StudentName = StudentName;
            att.Attendence = atten;
            att.Date = date;
            db.StudentAttens.Add(att);
            db.SaveChanges();
            return View();
        }


        public JsonResult GetStdList(int Id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var CityList = db.Students.Where(x => x.BatchId== Id).ToList();
            return Json(CityList, JsonRequestBehavior.AllowGet);


        }

        public ActionResult ShowAttendence()
        {


            var std = db.StudentAttens.ToList();
            ViewBag.StdAtt = std;
            return View();
        }
       


    }
}