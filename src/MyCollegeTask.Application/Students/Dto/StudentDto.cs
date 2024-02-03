using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyCollegeTask.Colleges.Dto;
using MyCollegeTask.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollegeTask.Students.Dto
{
    [AutoMapFrom(typeof(Student))]
    public class StudentDto : FullAuditedEntityDto<int>
    {
        public int? CollegeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ProgramName { get; set; }
        public string DoB { get; set; }
        public bool IsActive { get; set; }

        // Include navigation property if needed

    }
}
