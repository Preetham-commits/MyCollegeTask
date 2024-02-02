using Abp.Authorization;
using MyCollegeTask.Authorization.Roles;
using MyCollegeTask.Authorization.Users;

namespace MyCollegeTask.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
