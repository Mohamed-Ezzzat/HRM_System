using HRM_System.Models;

namespace HRM_System.Data.Base
{
    public class EmployeeSpecification
    {

    }
    public class GetEmployeeByName : BaseSpecification<Employee>
    {
        public GetEmployeeByName(string name) : base(I => I.Name.ToLower().Contains(name.ToLower()))
        {

        }
    }
}
