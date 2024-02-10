using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCollegeTask.Colleges.Dto;
using MyCollegeTask.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollegeTask.Colleges
{
    public interface ICollegeAppService : IApplicationService
    {
        Task<ListResultDto<CollegeDto>> GetAll();
        Task<CollegeDto> GetById(int id);
        Task<int> Create(CreateCollegeDto input);
        Task Update(CollegeDto input);
        Task Delete(int id);
    }
}
