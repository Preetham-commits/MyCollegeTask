using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyCollegeTask.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollegeTask.Colleges.Dto
{

    [AutoMapFrom(typeof(College))]
    public class CollegeDto : FullAuditedEntityDto<int>
    {

        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public bool IsActive { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
    }
}







