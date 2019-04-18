namespace ERS.Models
{
    public class EmpDivisionMap
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int DivisionId { get; set; }
        public Division Division { get; set; }

        public int ESSInfoId { get; set; }
        public ESSInfo ESSInfo { get; set; }
    }
}
