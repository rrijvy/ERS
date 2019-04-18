namespace ERS.Models
{
    public class EmpUpazilaMap
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int UpazilaId { get; set; }
        public Upazila Upazila { get; set; }

        public int ESSInfoId { get; set; }
        public ESSInfo ESSInfo { get; set; }
    }
}
