using Abp.Application.Services.Dto;

namespace MyCollegeTask.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

