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
        ApplicationDbContext context;

        public ReceptionistController()
        {
            context = new ApplicationDbContext();
        }

        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }

        // GET: Receptionist
        public ActionResult Index()
        {
            ReceptionistViewModel queueData = new ReceptionistViewModel();
            var waitingPatients = context.Visitations.Where(data => (data.Status == "waiting") || (data.Status == "in progress"));

            if(waitingPatients != null)
            {
                waitingPatients.OrderBy(data => data.Priority).ThenBy(data => data.VisitDate);
            }

            Patient visitor = new Patient();

            foreach(var item in waitingPatients)
            {
                visitor = context.Patients.Where(pa => pa.Id == item.PatientId).FirstOrDefault();
                if(CalculateAge(visitor.BirthDate) < 18)
                {
                    queueData.ForPediatrician.Add(new QueueViewModel
                    {
                        FirstName = visitor.FirstName,
                        LastName = visitor.LastName,
                        PhoneNumber = visitor.PhoneNumber,
                        Id = visitor.Id,
                        Status = item.Status,
                        Priority = item.Priority,
                        Doctor = item.DoctorName                        
                    });
                }
                else
                {
                    queueData.ForGeriatricians.Add(new QueueViewModel
                    {
                        FirstName = visitor.FirstName,
                        LastName = visitor.LastName,
                        PhoneNumber = visitor.PhoneNumber,
                        Id = visitor.Id,
                        Status = item.Status,
                        Priority = item.Priority,
                        Doctor = item.DoctorName
                    });
                }
            }            
            return View(queueData);
        }

        public ActionResult Home()
        {

            return View("Index");
        }

        public ActionResult Search()
        {
            List<SelectListItem> data = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "First Name",
                    Value = "First Name"
                },
                new SelectListItem
                {
                    Text = "Last Name",
                    Value = "Last Name"
                },
                new SelectListItem
                {
                    Text = "Phone Number",
                    Value = "Phone Number"
                }
            };
            ViewBag.list = data;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Result(SearchViewModel model)
        {

            List<SearchResultViewModel> result = new List<SearchResultViewModel>(); 

            if (model.type == "First Name")
            {
                var visitorResult = context.Patients.Where(data => data.FirstName.ToLower() == model.key.ToLower());
                foreach(var item in visitorResult)
                {
                    result.Add(new SearchResultViewModel
                    {
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        PhoneNumber = item.PhoneNumber
                    });
                }
            }
            else if (model.type == "First Name")
            {
                var visitorResult = context.Patients.Where(data => data.LastName.ToLower() == model.key.ToLower());
                foreach (var item in visitorResult)
                {
                    result.Add(new SearchResultViewModel
                    {
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        PhoneNumber = item.PhoneNumber
                    });
                }
            }
            else if (model.type == "First Name")
            {
                var visitorResult = context.Patients.Where(data => data.PhoneNumber.ToLower() == model.key.ToLower()).FirstOrDefault();
                result.Add(new SearchResultViewModel
                {
                    FirstName = visitorResult.FirstName,
                    LastName = visitorResult.LastName,
                    PhoneNumber = visitorResult.PhoneNumber
                });
            }

            return View(result);
        }

        public ActionResult CreatePatient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePatient(PatientViewModel patient)
        {
            Patient data = new Patient();

            data.FirstName = patient.FirstName;
            data.LastName = patient.LastName;
            data.PhoneNumber = patient.PhoneNumber;
            data.Email = patient.Email;
            data.Adderess = patient.Adderess;
            data.BirthDate = new DateTime(patient.BirthYear, patient.BirthMonth, patient.BirthDay);

            context.Patients.Add(data);

            context.SaveChanges();

            return RedirectToAction("Visitation", routeValues: new { Phone = patient.PhoneNumber });
        }

        public ActionResult Visitation(string Phone)
        {
            Patient visior = context.Patients.Where(user => user.PhoneNumber == Phone).FirstOrDefault();
            VisitorViewModel model = new VisitorViewModel();

            model.PatientId = visior.Id;
            model.FirstName = visior.FirstName;
            model.LastName = visior.LastName;
            model.VisitDate = DateTime.Now;

            List<SelectListItem> data = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Urgent",
                    Value = "a"
                },
                new SelectListItem
                {
                    Text = "Normal",
                    Value = "b"
                },               
            };

            ViewBag.piror = data;

            return View(model);
        }

        [HttpPost]
        public ActionResult Visitation(VisitorViewModel model)
        {
            Visitation data = new Visitation();

            data.PatientId = model.PatientId;
            data.Medicine = model.Medicine;
            data.Priority = model.Priority;
            data.ReasonForVisit = model.ReasonForVisit;
            data.VisitDate = model.VisitDate;
            data.Status = "waiting";

            context.Visitations.Add(data);
            context.SaveChanges();
            return RedirectToAction("index");
        }

        

        
    }
}