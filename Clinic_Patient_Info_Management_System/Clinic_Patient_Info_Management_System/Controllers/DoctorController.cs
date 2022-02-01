using Clinic_Patient_Info_Management_System.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic_Patient_Info_Management_System.Controllers
{
    public class DoctorController : Controller
    {
        ApplicationDbContext context;

        public DoctorController()
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
        // GET: Doctor
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            Employee doctor = context.Employees.Where(data => data.UserID == userId).FirstOrDefault();

            ReceptionistViewModel queueData = new ReceptionistViewModel();
            var waitingPatients = context.Visitations.Where(data => (data.Status == "waiting") || (data.Status == "in progress"));

            if (waitingPatients != null)
            {
                waitingPatients.OrderBy(data => data.Priority).ThenBy(data => data.VisitDate);
            }

            Patient visitor = new Patient();

            foreach (var item in waitingPatients)
            {
                visitor = context.Patients.Where(data => data.Id == item.PatientId).FirstOrDefault();
                if (CalculateAge(visitor.BirthDate) < 18)
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

            if(doctor.Specialty == "Pediatrician")
            {
                ViewBag.type = "Pediatrician";
                return View(queueData.ForPediatrician);
            }
            else
            {
                ViewBag.type = "Geriatrician";
                return View(queueData.ForGeriatricians);
            }
        }
        public ActionResult ViewPatient(int id)
        {
            var patient = context.Patients.Where(temp => temp.Id == id).FirstOrDefault();
            var visit = context.Visitations.Where(data => data.PatientId == id).OrderBy(data => data.VisitDate);

            DoctorViewModel model = new DoctorViewModel();

            model.FirstName = patient.FirstName;
            model.LastName = patient.LastName;

            bool ctr = false;
            foreach(var items in visit)
            {
                if (!ctr)
                {
                    model.current.Id = items.Id;
                    model.current.Medicine = items.Medicine;
                    model.current.Perscription = items.Perscription;
                    model.current.ReasonForVisit = items.ReasonForVisit;
                    model.current.VisitDate = items.VisitDate;
                    model.current.Diagnosis = items.Diagnosis;
                    ctr = true;
                }

                else
                {
                    model.past.Add(new Records
                    {
                        Id = items.Id,
                        Medicine = items.Medicine,
                        Perscription = items.Perscription,
                        ReasonForVisit = items.ReasonForVisit,
                        VisitDate = items.VisitDate,
                        Diagnosis = items.Diagnosis,
                    });
                }
            }


            return View(model);
        }

        [HttpPost]
        public ActionResult ViewPatient(Records current)
        {
            var visit = context.Visitations.Where(data => data.Id == current.Id).FirstOrDefault();

            visit.Perscription = current.Perscription;
            visit.Diagnosis = current.Diagnosis;
            visit.Status = "Finished";
            context.SaveChanges();

            return RedirectToAction("index");
        }


    }
}