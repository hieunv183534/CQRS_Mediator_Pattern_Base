
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using FluentValidation;
using MediatR;
using System.Reflection;
using NOM.DomainGlobal.Interfaces;
using NOM.DomainGlobal.Services;
using NOM.DomainGlobal._Services;
using NOM.BACKGROUND.Domain.Interfaces;
using NOM.BACKGROUND.Domain.Services;
using Hangfire;
using Hangfire.SqlServer;
using NOM.BACKGROUND.Domain.Hangfire;
using NOM.BACKGROUND.Domain._Services;
using NOM.BACKGROUND.Domain._Interfaces;

namespace NOM.BACKGROUND.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainModule(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //inject servive
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IHangfireWarningService, HangfireWarningService>();
            services.AddScoped<IHangfireReportService, HangfireReportService>();

            // Add the processing server as IHostedService
            // Add Hangfire services.
            services.AddHangfire(options => options
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
                {
                    //JobExpirationCheckInterval = TimeSpan.FromMinutes(5),
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(3),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true,
                    UsePageLocksOnDequeue = true,
                    UseIgnoreDupKeyOption = false,
                    SchemaName = "KT1"
                }));
            services.AddHangfireServer(options =>
            {
                options.WorkerCount = Math.Min(Environment.ProcessorCount * 5, 20);
                options.SchedulePollingInterval = TimeSpan.FromMinutes(1);
                options.HeartbeatInterval = TimeSpan.FromMinutes(1);
            });

            // Khơi chạy hangfire schedule
            services.AddHostedService<HangfireStartup>();
            return services;
        }
    }
}
