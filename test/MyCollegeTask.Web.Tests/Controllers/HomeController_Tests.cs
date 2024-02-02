using System.Threading.Tasks;
using MyCollegeTask.Models.TokenAuth;
using MyCollegeTask.Web.Controllers;
using Shouldly;
using Xunit;

namespace MyCollegeTask.Web.Tests.Controllers
{
    public class HomeController_Tests: MyCollegeTaskWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}