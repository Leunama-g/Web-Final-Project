using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinic_Patient_Info_Management_System.Models
{
    public class QueueViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        //values for status
        //1. waiting
        //2. in progress
        //3. done
        public string Status { get; set; }

        public string Doctor { get; set; }

        public string Priority { get; set; }
    }

    public class ReceptionistViewModel
    {
        public List<QueueViewModel> ForPediatrician;
        public List<QueueViewModel> ForGeriatricians;


        public ReceptionistViewModel()
        {
            ForPediatrician = new List<QueueViewModel>();
            ForGeriatricians = new List<QueueViewModel>();
        }
    }

    public class SearchResultViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }

    public class SearchViewModel
    {
        public string key { get; set; }

        public string type { get; set; }

    }

    public class PatientViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the Patients first name")]
        [MaxLength(50, ErrorMessage = "Nmber of characters should not be greater than 50")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter the Patients last name")]
        [MaxLength(50, ErrorMessage = "Nmber of characters should not be greater than 50")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter the Patients birthday")]
        public int BirthDay { get; set; }

        [Required(ErrorMessage = "Please enter the Patients birthmonth")]
        public int BirthMonth { get; set; }

        [Required(ErrorMessage = "Please enter the Patients birthyear")]
        public int BirthYear { get; set; }

        [Required(ErrorMessage = "Please enter the Patients email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter the Patients address")]
        public string Adderess { get; set; }

        [Required(ErrorMessage = "Please enter the Patients Phone number")]
        public string PhoneNumber { get; set; }

    }

    public class VisitorViewModel
    {

        public int PatientId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter the Patients Reason for visit")]
        public string ReasonForVisit { get; set; }

        public string Medicine { get; set; }

        public DateTime VisitDate { get; set; }

        [Required(ErrorMessage = "Please enter the priority of the visit")]
        public string Priority { get; set; }
    }
}