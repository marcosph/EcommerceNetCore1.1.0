using System.IO;
using Gzt.Infra.CrossCutting.Identity.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Gzt.Infra.CrossCutting.Identity.Models;
using AutoMapper;
using Gzt.Infra.CrossCutting.Bus;
using Gzt.Infra.CrossCutting.Identity.Authorization;
using Gzt.Infra.CrossCutting.IoC;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using GazetaDoTocantins.UI.Site.Filters;
using GazetaDoTocantins.UI.Site.Services;

namespace GazetaDoTocantins.UI.Site
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAntiforgery(opts => opts.HeaderName = "X-XSRF-Token");
            services.AddMvc(opts =>
            {
                opts.Filters.AddService(typeof(AngularAntiforgeryCookieResultFilter));
                opts.Filters.AddService(typeof(ValidateOriginAuthorizationFilter));
            });
            services.AddTransient<AngularAntiforgeryCookieResultFilter>();
            services.AddTransient<ValidateOriginAuthorizationFilter>();
            services.AddSingleton<ITodoService, TodoService>();
            var supportedCultures = new[]
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("en-GB"),
                    new CultureInfo("de"),
                    new CultureInfo("fr-FR"),
                };

                    var op = new RequestLocalizationOptions()
                    {
                        DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
                        SupportedCultures = supportedCultures,
                        SupportedUICultures = supportedCultures
                    };
                    op.RequestCultureProviders = new[]
                    {
                 new RouteDataRequestCultureProvider() { Options = op }
            };

            services.AddSingleton(op);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddIdentity<User, IdentityRole>(options =>
                    options.Cookies.ApplicationCookie.AccessDeniedPath = "/home/access-denied")
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
            services.AddAutoMapper();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanWriteCustomerData", policy => policy.Requirements.Add(new ClaimRequirement("Customers", "Write")));
                options.AddPolicy("CanRemoveCustomerData", policy => policy.Requirements.Add(new ClaimRequirement("Customers", "Remove")));
            });

            // .NET Native DI Abstraction
            RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app,
                                      IHostingEnvironment env,
                                      ILoggerFactory loggerFactory,
                                      IHttpContextAccessor accessor)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseIdentity();

            app.UseFacebookAuthentication(new FacebookOptions()
            {
                AppId = "SetYourDataHere",
                AppSecret = "SetYourDataHere"
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=welcome}/{id?}");
            });

            // Setting the IContainer interface for use like service locator for events.
            InMemoryBus.ContainerAccessor = () => accessor.HttpContext.RequestServices;
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            SimpleInjectorBootStrapper.RegisterServices(services);
        }
    }
}
