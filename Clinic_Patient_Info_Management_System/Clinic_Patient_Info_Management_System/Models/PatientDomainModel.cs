using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinic_Patient_Info_Management_System.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public string Adderess { get; set; }

        public string PhoneNumber { get; set; }

    }

    public class Visitation
    {
        [Key]
        public int Id { get; set; }

        public string PatientId { get; set; }

        public string ReasonForVisit { get; set; }

        public string Medicine { get; set; }

        public DateTime VisitDate { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public string DoctorName { get; set; }

        public string Diagnosis { get; set; }

        public string Perscription { get; set; }

    }
}