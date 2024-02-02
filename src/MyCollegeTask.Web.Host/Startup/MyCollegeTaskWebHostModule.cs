using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyCollegeTask.Configuration;

namespace MyCollegeTask.Web.Host.Startup
{
    [DependsOn(
       typeof(MyCollegeTaskWebCoreModule))]
    public class MyCollegeTaskWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MyCollegeTaskWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyCollegeTaskWebHostModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            System.AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            System.AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            // https://www.npgsql.org/efcore/release-notes/6.0.html?tabs=annotations
        }
    }
}
