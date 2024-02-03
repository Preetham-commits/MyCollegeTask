using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollegeTask.Colleges.Dto
{
    public class PagedCollegeResultRequestDto : PagedResultRequestDto
    {

        public bool? IsActive { get; set; }
    }
}
