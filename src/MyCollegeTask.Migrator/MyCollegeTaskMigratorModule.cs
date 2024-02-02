using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyCollegeTask.Configuration;
using MyCollegeTask.EntityFrameworkCore;
using MyCollegeTask.Migrator.DependencyInjection;

namespace MyCollegeTask.Migrator
{
    [DependsOn(typeof(MyCollegeTaskEntityFrameworkModule))]
    public class MyCollegeTaskMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public MyCollegeTaskMigratorModule(MyCollegeTaskEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(MyCollegeTaskMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                MyCollegeTaskConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyCollegeTaskMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
