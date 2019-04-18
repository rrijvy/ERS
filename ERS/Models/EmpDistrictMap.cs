namespace ERS.Models
{
    public class EmpDistrictMap
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int DistrictId { get; set; }
        public District District { get; set; }

        public int ESSInfoId { get; set; }
        public ESSInfo ESSInfo { get; set; }
    }
}
