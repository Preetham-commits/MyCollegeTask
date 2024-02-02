using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyCollegeTask.MultiTenancy;

namespace MyCollegeTask.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
