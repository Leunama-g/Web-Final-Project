using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic_Patient_Info_Management_System.Models
{
    public class Records
    {
        public int Id { get; set; }
        public string ReasonForVisit { get; set; }
        public string Medicine { get; set; }
        public string Diagnosis { get; set; }
        public string Perscription { get; set; }
        public DateTime VisitDate { get; set; }

    }

    public class DoctorViewModel
    {
        public DoctorViewModel()
        {
            current = new Records();
            past = new List<Records>();
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Records current { get; set; }

        public List<Records> past { get; set; }
    }
}