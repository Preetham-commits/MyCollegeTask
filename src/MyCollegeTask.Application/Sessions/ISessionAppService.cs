using System.Threading.Tasks;
using Abp.Application.Services;
using MyCollegeTask.Sessions.Dto;

namespace MyCollegeTask.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
