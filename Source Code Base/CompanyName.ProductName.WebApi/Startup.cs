using Amazon.S3;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AspireSystems.Api.Filters.Exception;
using AspireSystems.Diagnostics.ErrorHandler;
using AspireSystems.Infrastructure.Models;
using AspireSystems.TakeYourJob.BusinessService.Context;
using AspireSystems.TakeYourJob.WebApi.Mappers;
using AspireSystems.TakeYourJob.WebApi.Registry;
using AspireSystems.TakeYourJob.BusinessService.ServiceContracts;
using AspireSystems.TakeYourJob.BusinessService.Services;
using AspireSystems.TakeYourJob.BusinessService.RepositoryContracts;
using AspireSystems.TakeYourJob.BusinessService.Repository;
using AspireSystems.TakeYourLogin.BusinessService.Repository;

namespace AspireSystems.TakeYourJob.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }
        public IConfiguration Configuration { get; }
        public AppSettings AppSettings { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US");
            });

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            services.AddCors();
            services.AddMvc();

            // configure jwt authentication
            AppSettings = appSettingsSection.Get<AppSettings>();
            DependencyRegistry.ResolveDependency(services);
            var exceptionHandler = services.BuildServiceProvider().GetService<IAspireSystemsExceptionHandler>();
            services.AddMvc(config =>
            {
                config.Filters.Add(new GlobalExceptionFilterAttribute(exceptionHandler));
            });
            services.AddDbContext<Dbcontext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AspireSystemsConnectionString")));
            services.AddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();
            services.AddScoped<IContext, Dbcontext>();
            services.AddScoped<IInterviewerService, InterviewerService>();
            services.AddScoped<IInterviewerRepository, InterviewerRepository>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IAppliedCandidateService, AppliedCandidateService>();
            services.AddScoped<IAppliedCandidateRepository, AppliedCandidateRepository>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ILoginRepository, LoginRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            AspireSystems.Infrastructure.Helpers.HttpContext.Configure(app.ApplicationServices.GetRequiredService<Microsoft.AspNetCore.Http.IHttpContextAccessor>());
            AspireSystems.Infrastructure.Helpers.UserIdentity.Configure(app.ApplicationServices.GetRequiredService<AspireSystems.Infrastructure.Providers.IUserIdentityProvider>());

            app.UseAuthentication();
            MapperConfig.Configure();
            app.UseRequestLocalization();
            app.UseMvc();
        }
    }
}
