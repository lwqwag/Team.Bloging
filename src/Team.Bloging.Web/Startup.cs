using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace Team.Blogging.Web
{
    public class Startup
    {
      

    

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<BlogingWebModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            app.InitializeApplication();
        }
    }
}
