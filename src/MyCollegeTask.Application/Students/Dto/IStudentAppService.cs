using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCollegeTask.Colleges.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollegeTask.Students.Dto
{
    internal interface IStudentAppService : IApplicationService
    {
        Task<ListResultDto<StudentDto>> GetAll();
        Task<StudentDto> GetById(int id);
        Task<int> Create(CreateStudentDto input);
        Task Update(StudentDto input);
        Task Delete(int id);
    }
}
