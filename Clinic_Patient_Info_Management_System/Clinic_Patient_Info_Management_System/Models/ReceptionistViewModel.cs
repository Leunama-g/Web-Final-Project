using System;
using System.Collections.Generic;
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

        public List<SearchResultViewModel> Result { get; set; }
    }
}