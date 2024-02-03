using Abp.Application.Services;
using MyCollegeTask.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollegeTask.Colleges.Dto
{
    public interface ICollegeAppSevice : IAsyncCrudAppService<CollegeDto, int, PagedCollegeResultRequestDto, CreateCollegeDto, CollegeDto>
    {
    }
}
