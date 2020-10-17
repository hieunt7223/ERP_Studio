using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace xdcb.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<xdcbWebModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }
    }
}
