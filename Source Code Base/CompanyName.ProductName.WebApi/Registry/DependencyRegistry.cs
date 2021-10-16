using Microsoft.Extensions.DependencyInjection;
using AspireSystems.Api.Base.Responses;
using AspireSystems.Api.Base.Responses.Contracts;
using AspireSystems.Api.BaseMapperContracts;
using AspireSystems.Api.BaseMappers;
using AspireSystems.Api.ControllerContracts;
using AspireSystems.Api.Controllers;
using AspireSystems.Diagnostics.ErrorHandler;
using AspireSystems.Diagnostics.Logging;
using AspireSystems.Infrastructure.Authentication.Cryptography;
using AspireSystems.Infrastructure.Authentication.Cryptography.Contracts;
using AspireSystems.Infrastructure.FileUpload;
using AspireSystems.Infrastructure.FileUpload.Contract;
using AspireSystems.Infrastructure.Helpers;
using AspireSystems.Infrastructure.MailNotification.Contracts;
using AspireSystems.Infrastructure.Providers;
using AspireSystems.Infrastructure.QueueHelper;
using AspireSystems.Infrastructure.QueueHelper.Contract;
using AspireSystems.TakeYourJob.BusinessService.Context;
using AspireSystems.TakeYourJob.BusinessService.Repository;
using AspireSystems.TakeYourJob.BusinessService.RepositoryContracts;
using AspireSystems.TakeYourJob.BusinessService.ServiceContracts;
using AspireSystems.TakeYourJob.BusinessService.Services;

namespace AspireSystems.TakeYourJob.WebApi.Registry
{
    public static class DependencyRegistry
    {
        /// <summary>
        /// Registers the dependency with its implementation
        /// </summary>
        public static void ResolveDependency(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IUserIdentityProvider, AspireSystemsUserIdentityProvider>();

            //Register Repository
            services.AddScoped<IApplicantRepository, ApplicantRepository>();

            //Register Services
            services.AddScoped<IApplicantService, ApplicantService>();
            
            //Register Context
            services.AddScoped<IContext, Dbcontext>();

            //Register Mapper
            services.AddScoped(typeof(IBaseDtoToModelMapper<,>), typeof(BaseDtoToModelMapper<,>));
            services.AddScoped(typeof(IBaseModelToDtoMapper<,>), typeof(BaseModelToDtoMapper<,>));

            //Register Base Controller
            services.AddScoped(typeof(IBaseAsyncController<,>), typeof(BaseAsyncController<,>));

            //Register Response
            services.AddScoped<IAspireSystemsApiResponse, AspireSystemsApiResponse>();
            services.AddScoped(typeof(IAspireSystemsApiMessage<>), typeof(AspireSystemsApiMessage<>));

            //Register Logger
            services.AddScoped<IDefaultLogger, DefaultLogger>();
            //services.AddScoped<IDefaultLogger, CompanyName.Infrastructure.Logging.CompanyNameDBLogger>();

            //Register Exception Handler
            services.AddScoped<IAspireSystemsExceptionHandler, AspireSystemsExceptionHandler>();

            //Register base mailnotification service
            services.AddScoped<IDefaultMailNotificationService, DefaultMailNotificationService>();

            //Register cryptography
            services.AddScoped<ICryptography, Cryptography>();

            //Register Blobhandler
            services.AddScoped<IBlobHandler, BlobHandler>();

            //Register Queuehandler
            services.AddScoped<IQueueHandler, QueueHandler>();
        }
    }
}
