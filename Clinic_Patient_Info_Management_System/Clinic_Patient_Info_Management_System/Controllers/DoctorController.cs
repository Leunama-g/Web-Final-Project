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
            int userId = User.Identity.GetUserId<int>();
            var specialties = context.Doctor.Where(doctor => doctor.Id == userId).FirstOrDefault();

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
                if (CalculateAge(visitor.BirthDate) < 18 && specialties.ToString()=="Pediatrician")
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
        public ActionResult viewPatient(int id)
        {
            var patient = context.Employees.Where(temp => temp.Id == id).FirstOrDefault();
            return View(patient);
        }
        public ActionResult viewVisitation(int id)
        {
            var visitation = context.Visitations.Where(temp => temp.Id == id).FirstOrDefault();
            return View(visitation);
        }
    }
}