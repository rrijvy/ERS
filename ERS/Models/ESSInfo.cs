using System;
using System.ComponentModel.DataAnnotations;

namespace ERS.Models
{
    public class ESSInfo
    {
        public int Id { get; set; }

        public string ESSCode { get; set; }

        [Display(Name = "Working Area:")]
        public string WorkingArea { get; set; }

        public DateTime EntryTime { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}