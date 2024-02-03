using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollegeTask.Students.Dto
{
    public class PagedStudentResultRequestDto : PagedResultRequestDto
    {
        public bool? IsActive { get; set; }
    }
}
