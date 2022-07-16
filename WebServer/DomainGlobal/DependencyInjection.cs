//using NOM.DomainGlobal._Base.Behaviours;
////using NOM.DomainGlobal._Services;
//using NOM.DomainGlobal.Interfaces;
//using NOM.DomainGlobal.Services;
//using MediatR;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;

//namespace NOM.DomainGlobal
//{
//    public static class DependencyInjection
//    {
//        public static IServiceCollection AddDomainGlobalModule(this IServiceCollection services, IConfiguration configuration)
//        {
//            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
//            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
//            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

//            //inject servive
//            services.AddScoped<IUserService, UserService>();
//            services.AddScoped<IFileCenterService, FileCenterService>();
//            services.AddScoped<IVmapService, VmapService>();
//            services.AddScoped<ICodeService, CodeService>();
//            services.AddScoped<IExtentionService, ExtentionService>();

//            return services;
//        }
//    }
//}
