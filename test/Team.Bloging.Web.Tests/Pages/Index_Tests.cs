using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Team.Blogging.Pages
{
    public class Index_Tests : BlogingWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
