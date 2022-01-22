using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic_Patient_Info_Management_System.Models
{
    public class AdminIndexViewModel
    {
        public string UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Type { get; set; }
    }


    public class RegisterEmpViewModel
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the employees first name")]
        [MaxLength(50, ErrorMessage = "Nmber of characters should not be greater than 50")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter the employees last name")]
        [MaxLength(50, ErrorMessage = "Nmber of characters should not be greater than 50")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter the employees email address")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter the employees birth date")]
        public int Birthdate { get; set; }

        [Required(ErrorMessage = "Please enter the employees birth month")]
        public int BirthMonth { get; set; }

        [Required(ErrorMessage = "Please enter the employees birth year")]
        public int BirthYear { get; set; }

        [Required(ErrorMessage = "Please enter the employees address")]
        public string Adderess { get; set; }

        [Required(ErrorMessage = "Please enter the employees phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter the employees occupation")]
        public string AccountType { get; set; }

        public string Specialty { get; set; }
    }

    public class EditEmpViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the employees first name")]
        [MaxLength(50, ErrorMessage = "Nmber of characters should not be greater than 50")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter the employees last name")]
        [MaxLength(50, ErrorMessage = "Nmber of characters should not be greater than 50")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter the employees email address")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter the employees birth date")]
        public int Birthdate { get; set; }

        [Required(ErrorMessage = "Please enter the employees birth month")]
        public int BirthMonth { get; set; }

        [Required(ErrorMessage = "Please enter the employees birth year")]
        public int BirthYear { get; set; }

        [Required(ErrorMessage = "Please enter the employees address")]
        public string Adderess { get; set; }

        [Required(ErrorMessage = "Please enter the employees phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter the employees occupation")]
        public string AccountType { get; set; }

        public string Specialty { get; set; }
    }
}