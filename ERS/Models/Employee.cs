using System.ComponentModel.DataAnnotations;

namespace ERS.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name="Name:")]
        public string Name { get; set; }

        [Display(Name = "Designation:")]
        public string Designation { get; set; }

        [Display(Name = "Phone:")]
        public string Phone { get; set; }
    }
}
