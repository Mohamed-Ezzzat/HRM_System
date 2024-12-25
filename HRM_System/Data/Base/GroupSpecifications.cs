using HRM_System.Models;

namespace HRM_System.Data.Base
{
    public class GroupSpecifications
    {

    }
    public class GetGroupByName : BaseSpecification<Usergroupsandpermissions>
    {
        public GetGroupByName(string name) : base(I => I.Name.ToLower().Contains(name.ToLower())) { }

    }

    public class GetOfficialByName : BaseSpecification<Officialleavesettings>
    {
        public GetOfficialByName(string name) : base(I => I.Name.ToLower().Contains(name.ToLower())) { }
    }
    public class GetNationalIDofEmployee : BaseSpecification<Employee>
    {
        public GetNationalIDofEmployee(string NationalID) : base(I => I.NationalID.Contains(NationalID)) { }
    }
}
