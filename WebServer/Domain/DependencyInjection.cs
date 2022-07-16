using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NOM.Domain._Base.Behaviours;
using System.Reflection;

namespace NOM.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainModule(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
            services.AddMediatR(assembly);
            services.AddValidatorsFromAssembly(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

            //inject servive
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IVmapService, VmapService>();
            //services.AddScoped<IEmailSenderService, EmailSenderService>();

            //services.AddScoped<INotificationService, NotificationService>();
            //services.AddScoped<IExtentionService, ExtentionService>();

            //services.RegisterEasyNetQ("host=localhost:5672", reg =>
            //{
            //    reg.Register<IAdvancedBus, MyBus>(); //  public class MyBus : RabbitAdvancedBus
            //});

            //var rabbitMqSection = Configuration.GetSection("RabbitMq");
            //var exchangeSection = Configuration.GetSection("RabbitMqExchange");

            //services.AddRabbitMqClient(rabbitMqSection)
            //    .AddConsumptionExchange("exchange.log", exchangeSection)
            //    .AddMessageHandlerTransient<LogMessageHandler>("log.test");

            //services.AddSingleton<IHostedService, ConsumingService>();

            /// signalR
            services.AddSignalR();

            return services;
        }
    }
}