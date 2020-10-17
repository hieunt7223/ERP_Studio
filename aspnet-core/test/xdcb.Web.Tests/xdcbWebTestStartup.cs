using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace xdcb
{
    public class xdcbWebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<xdcbWebTestModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}