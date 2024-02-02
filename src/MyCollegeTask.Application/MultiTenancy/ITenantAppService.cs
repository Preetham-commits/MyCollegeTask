using Abp.Application.Services;
using MyCollegeTask.MultiTenancy.Dto;

namespace MyCollegeTask.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

