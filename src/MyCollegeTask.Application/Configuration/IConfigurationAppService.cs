using System.Threading.Tasks;
using MyCollegeTask.Configuration.Dto;

namespace MyCollegeTask.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
