using ERS.Models;
using System.Collections.Generic;

namespace ERS.ViewModels
{
    public class ProductTemplateViewModel
    {
        public string TemplateName { get; set; }
        public List<Prod> Products { get; set; }
    }

    public class Prod
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
    }
}
