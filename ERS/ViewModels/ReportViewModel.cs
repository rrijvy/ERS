using ERS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERS.ViewModels
{
    public class ReportViewModel
    {
        public ESSInfo ESSInfo { get; set; }
        public Employee Employee { get; set; }
        public List<EmpProductMap> EmpProductMap { get; set; }
        public List<EmpDivisionMap> EmpDivisionMap { get; set; }
        public List<EmpDistrictMap> EmpDistrictMap { get; set; }
        public List<EmpUpazilaMap> EmpUpazilaMap { get; set; }
    }
}
