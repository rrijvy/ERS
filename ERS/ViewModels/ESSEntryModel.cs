using ERS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERS.ViewModels
{
    public class ESSEntryModel
    {
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string EmployeePhone { get; set; }
        public string WorkingArea { get; set; }
        public List<Division> Divisions { get; set; }
        public List<District> Districts { get; set; }
        public List<Upazila> Upazilas { get; set; }
    }
}
