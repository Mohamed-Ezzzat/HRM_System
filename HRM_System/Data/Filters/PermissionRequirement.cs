using Microsoft.AspNetCore.Authorization;

namespace HRM_System.Data.Filters
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string Permission { get; private set; }
        public PermissionRequirement(string permission)
        {
                Permission = permission;
        }

    }
}
