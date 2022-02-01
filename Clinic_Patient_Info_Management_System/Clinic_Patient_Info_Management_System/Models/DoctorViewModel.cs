using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic_Patient_Info_Management_System.Models
{
    public class DoctorViewModel
    {
        public Patient Patients;
        public IQueryable<Visitation> Visitations;
    }
}