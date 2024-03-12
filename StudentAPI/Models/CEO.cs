using HRAdminstration;

namespace StudentAPI.Models
{
    public class CEO : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + base.Salary * 0.05M; }
    }
}
