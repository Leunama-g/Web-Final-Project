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
        public int Id { get; set; }

        public string UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public string Email { get; set; }

        public string Adderess { get; set; }

        public string PhoneNumber { get; set; }

        public string Specialty { get; set; }

    }

    public class Receptionist
    {
        [Key]
        public int Id { get; set; }

        public string UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public string Email { get; set; }

        public string Adderess { get; set; }

        public string PhoneNumber { get; set; }

    }

    public class LabTech
    {
        [Key]
        public int Id { get; set; }

        public string UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public string Email { get; set; }

        public string Adderess { get; set; }

        public string PhoneNumber { get; set; }

    }

    public class Admin
    {
        [Key]
        public int Id { get; set; }

        public string UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public string Email { get; set; }

        public string Adderess { get; set; }

        public string PhoneNumber { get; set; }

    }

    public class Specialties
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}