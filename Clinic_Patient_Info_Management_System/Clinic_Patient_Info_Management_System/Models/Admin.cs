using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinic_Patient_Info_Management_System.Models
{
    public class Admin
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public string phone { get; set; }

        public string email { get; set; }
    }
}