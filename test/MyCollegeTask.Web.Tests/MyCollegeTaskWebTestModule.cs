using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyCollegeTask.EntityFrameworkCore;
using MyCollegeTask.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MyCollegeTask.Web.Tests
{
    [DependsOn(
        typeof(MyCollegeTaskWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class MyCollegeTaskWebTestModule : AbpModule
    {
        public MyCollegeTaskWebTestModule(MyCollegeTaskEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyCollegeTaskWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MyCollegeTaskWebMvcModule).Assembly);
        }
    }
}