using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyCollegeTask.Configuration.Dto;

namespace MyCollegeTask.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MyCollegeTaskAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
