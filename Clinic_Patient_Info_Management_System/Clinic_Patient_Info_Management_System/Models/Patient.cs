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
        public int id { get; set; }

        public string name { get; set; }
        
        public int age { get; set; }

        public string gender { get; set; }

        public string phone { get; set; }

        public  string address { get; set; }

        public string email { get; set; }
    }
}