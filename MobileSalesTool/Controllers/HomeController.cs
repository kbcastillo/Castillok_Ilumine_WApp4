using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileSalesTool.DAL;
using MobileSalesTool.ViewModels;

namespace MobileSalesTool.Controllers
{
    public class HomeController : Controller
    {
        private MobileSalesToolContext db = new MobileSalesToolContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<EnrollmentDateGroup> data = from employee in db.Employees
                                                   group employee by employee.EnrollmentDate into dateGroup
                                                   select new EnrollmentDateGroup()
                                                   {
                                                       EnrollmentDate = dateGroup.Key,
                                                       EmployeeCount = dateGroup.Count()
                                                   };
            return View(data.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Chat()
        {
            return View();
        }
    }
}