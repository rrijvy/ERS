using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERS.Models
{
    public class EmpProductMap
    {
        public int Id { get; set; }

        public double Quantity { get; set; }

        public double Price { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ESSInfoId { get; set; }
        public ESSInfo ESSInfo { get; set; }
    }
}
