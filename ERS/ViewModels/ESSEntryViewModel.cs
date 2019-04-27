using ERS.Models;
using System.Collections.Generic;

namespace ERS.ViewModels
{
    public class ESSEntryViewModel
    {
        public Employee Employee { get; set; }
        public Division Division { get; set; }
        public District District { get; set; }
        public Upazila Upazila { get; set; }
        public Product Product { get; set; }
        public ProductTemplate ProductTemplate { get; set; }
        public ESSInfo ESSInfo { get; set; }
        public List<Product> Products { get; set; }
        public List<Division> Divisions { get; set; }
        public List<District> Districts { get; set; }
        public List<Upazila> Upazilas { get; set; }
    }
}
