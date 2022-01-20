using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Clinic_Patient_Info_Management_System.Models
{
    public class Doctor
    {
        [Key]
        public int id { get; set; }

        public string email { get; set; }

    }
}