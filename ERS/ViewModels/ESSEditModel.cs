using ERS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERS.ViewModels
{
    public class ESSEditModel
    {
        public string ESSCode { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string WorkingArea { get; set; }
        public string Phone { get; set; }
        public List<EmpDivisionMap> EmpDivisions { get; set; }
        public List<EmpDistrictMap> EmpDistricts { get; set; }
        public List<EmpUpazilaMap> EmpUpazilas { get; set; }
        public List<EmpProductMap> EmpProducts { get; set; }

        public List<Product> Products { get; set; }
        public List<Division> Divisions { get; set; }
        public List<District> Districts { get; set; }
        public List<Upazila> Upazilas { get; set; }
        public List<string> ProductTemplates { get; set; }
    }
}
