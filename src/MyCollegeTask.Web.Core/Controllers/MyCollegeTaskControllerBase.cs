using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MyCollegeTask.Controllers
{
    public abstract class MyCollegeTaskControllerBase: AbpController
    {
        protected MyCollegeTaskControllerBase()
        {
            LocalizationSourceName = MyCollegeTaskConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
