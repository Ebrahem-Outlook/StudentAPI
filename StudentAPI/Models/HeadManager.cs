using HRAdminstration;

namespace StudentAPI.Models
{
    public class HeadManager : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + base.Salary * 0.04M; }
    }
}
