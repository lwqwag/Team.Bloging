using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Team.Bloging.MongoDb;
using Team.Bloging.Localization;
using Team.Bloging.MultiTenancy;
using Team.Bloging.Web.Menus;
using Swashbuckle.AspNetCore.Swagger;
using Volo.Abp;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Data;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Web;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.Web;
using Volo.Abp.TenantManagement.Web;
using Volo.Abp.Threading;
using Volo.Abp.Ui.Navigation.Urls;
using Volo.Abp.UI;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Volo.Blogging;
using Volo.Blogging.Files;

namespace Team.Bloging.Web
{
    [DependsOn(
        typeof(BlogingHttpApiModule),
        typeof(BlogingApplicationModule),
        typeof(BlogingMongoDbModule),
        typeof(AbpAutofacModule),
        typeof(AbpIdentityWebModule),
        typeof(AbpAccountWebIdentityServerModule),
        typeof(AbpAspNetCoreMvcUiBasicThemeModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        typeof(AbpTenantManagementWebModule),
        typeof(BloggingTestAppMongoDbModule)
        )]
    [DependsOn(
        typeof(BloggingWebModule),
        typeof(BloggingApplicationModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementDomainIdentityModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpAutofacModule))]
    public class BlogingWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(
                    typeof(BlogingResource),
                    typeof(BlogingDomainModule).Assembly,
                    typeof(BlogingDomainSharedModule).Assembly,
                    typeof(BlogingApplicationModule).Assembly,
                    typeof(BlogingApplicationContractsModule).Assembly,
                    typeof(BlogingWebModule).Assembly
                );
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<BloggingUrlOptions>(options =>
            {
                options.RoutePrefix = null;
            });
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            ConfigureUrls(configuration);
            ConfigureAuthentication(context, configuration);
            ConfigureAutoMapper();
            ConfigureVirtualFileSystem(hostingEnvironment);
            ConfigureLocalizationServices();
            ConfigureNavigationServices();
            ConfigureAutoApiControllers();
            ConfigureSwaggerServices(context.Services);
            var cultures = new List<CultureInfo>
            {
                new CultureInfo("cs"),
                new CultureInfo("en"),
                new CultureInfo("tr"),
                new CultureInfo("zh-Hans")
            };
            Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en");
                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });
            Configure<ThemingOptions>(options =>
            {
                options.DefaultThemeName = BasicTheme.Name;
            });

            Configure<BlogFileOptions>(options =>
            {
                options.FileUploadLocalFolder = Path.Combine(hostingEnvironment.WebRootPath, "files");
            });
        }

        private void ConfigureUrls(IConfigurationRoot configuration)
        {
            Configure<AppUrlOptions>(options =>
            {
                options.Applications["MVC"].RootUrl = configuration["AppSelfUrl"];
            });
        }

        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfigurationRoot configuration)
        {
            context.Services.AddAuthentication()
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "Bloging";
                });
        }

        private void ConfigureAutoMapper()
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                /* use `true` for the `validate` parameter if you want to
                 * validate the profile on application startup.
                 * See http://docs.automapper.org/en/stable/Configuration-validation.html for more
                 * about configuration validation.
                 */
                options.AddProfile<BlogingWebAutoMapperProfile>();
            });
        }

        private void ConfigureVirtualFileSystem(IHostingEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.IsDevelopment())
            {
                Configure<VirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<BlogingDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}Team.Bloging.Domain.Shared", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<BlogingDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}Team.Bloging.Domain", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<BlogingApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}Team.Bloging.Application.Contracts", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<BlogingApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}Team.Bloging.Application", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<BlogingWebModule>(hostingEnvironment.ContentRootPath);
                });
            }
        }

        private void ConfigureLocalizationServices()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<BlogingResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );

                options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
                options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            });
        }

        private void ConfigureNavigationServices()
        {
          
            Configure<NavigationOptions>(options =>
            {
                options.MenuContributors.Add(new BlogingMenuContributor());
            });
           
        }

        private void ConfigureAutoApiControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(BlogingApplicationModule).Assembly);
            });
        }

        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new Info { Title = "Bloging API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                }
            );
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            if (context.GetEnvironment().IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseErrorPage();
            }

            app.UseVirtualFiles();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Support APP API");
            });

            app.UseAuthentication();

            app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultWithArea",
                    template: "{area}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


            using (var scope = context.ServiceProvider.CreateScope())
            {
                AsyncHelper.RunSync(async () =>
                {
                    await scope.ServiceProvider
                        .GetRequiredService<IDataSeeder>()
                        .SeedAsync();
                });
            }
        }
    }
}
