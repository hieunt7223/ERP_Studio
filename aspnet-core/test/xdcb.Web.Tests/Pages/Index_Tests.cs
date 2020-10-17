using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace xdcb.Pages
{
    public class Index_Tests : xdcbWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
