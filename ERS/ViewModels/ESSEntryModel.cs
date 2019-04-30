using ERS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERS.ViewModels
{
    public class ESSEntryModel
    {
        public ESSEntryModel()
        {
            Products = new List<Prod>();
            Divisions = new List<string>();
            Districts = new List<string>();
            Upazilas = new List<string>();
        }

        public string ESSCode { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string EmployeePhone { get; set; }
        public string WorkingArea { get; set; }
        public List<string> Divisions { get; set; }
        public List<string> Districts { get; set; }
        public List<string> Upazilas { get; set; }
        public List<Prod> Products { get; set; }
    }
}
