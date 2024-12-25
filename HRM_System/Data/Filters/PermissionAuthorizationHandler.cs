using System.Linq;
using System.Threading.Tasks;
using HRM_System.Constants;
using Microsoft.AspNetCore.Authorization;

namespace HRM_System.Data.Filters
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        public PermissionAuthorizationHandler()
        {

        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.User == null)
                return;

            var CanAccess = context.User.Claims.Any(c=>c.Type == Permission.Permission.ToString() &&
            c.Value == requirement.Permission && c.Issuer == "LOCAL AUTHORITY");

            if (CanAccess)
            {
                context.Succeed(requirement);
                return;
            }
        }
    }
}
