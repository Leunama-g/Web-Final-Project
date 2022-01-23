using Clinic_Patient_Info_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic_Patient_Info_Management_System.Controllers
{
    public class ReceptionistController : Controller
    {
        // GET: Receptionist
        public ActionResult Index(string search = "")
        {
            return View();
        }

        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Receptionist receptionist)
        {
            return RedirectToAction("index");
        }
        public ActionResult Sendin()
        {
            return View();
        }
        public ActionResult search()
        {
            return View();
        }

    }
}