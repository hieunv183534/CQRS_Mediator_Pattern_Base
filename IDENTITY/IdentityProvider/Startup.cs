using System;
using System.Linq;
using System.Reflection;
using IdentityProvider.Dao;
using IdentityProvider.Interfaces;
using IdentityProvider.Models;
using IdentityProvider.Quickstart;
using IdentityProvider.Services;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityProvider
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureNonBreakingSameSiteCookies();

            var emailConfig = Configuration.GetSection("EmailConfiguration").Get<EmailConfigurationModel>();
            services.AddSingleton(emailConfig);

            services.AddControllersWithViews();
            services.AddScoped<IEmailSenderService, EmailSenderService>();

            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.Configure<DataProtectionTokenProviderOptions>(o =>
            {
                o.Name = "Default";
                o.TokenLifespan = TimeSpan.FromHours(1);
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(
                       Configuration.GetConnectionString("Kt1Connection")));

            services.AddDbContext<IdentityApplicationDbContext>(builder =>
                builder.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                //options.Tokens.ProviderMap.Add("Default", new TokenProviderDescriptor(typeof(IUserTwoFactorTokenProvider<IdentityUser>)));
                options.Lockout.MaxFailedAccessAttempts = 20;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(365000);
            })
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<IdentityApplicationDbContext>();


            IIdentityServerBuilder ids = services.AddIdentityServer()
                .AddDeveloperSigningCredential();

            // in-memory client and scope stores
            //ids.AddInMemoryClients(Clients.Get())
            //    .AddInMemoryIdentityResources(Resources.GetIdentityResources())
            //    .AddInMemoryApiResources(Resources.GetApiResources())
            //    .AddInMemoryApiScopes(Resources.GetApiScopes());

            //ids.Services.ConfigureExternalCookie(options =>
            //{
            //    options.Cookie.IsEssential = true;
            //    options.Cookie.SameSite = SameSiteMode.Lax;
            //});

            //ids.Services.ConfigureApplicationCookie(options =>
            //{
            //    options.Cookie.IsEssential = true;
            //    options.Cookie.SameSite = SameSiteMode.Lax;
            //});

            // EF client, scope, and persisted grant stores
            ids.AddOperationalStore(options =>
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")))
                .AddConfigurationStore(options =>
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));

            // ASP.NET Identity integration
            ids.AddAspNetIdentity<IdentityUser>();
            ids.AddProfileService<IdentityClaimsProfileService>();

            //services.AddScoped<IUserClaimsPrincipalFactory<IdentityUser>,
            //    AdditionalUserClaimsPrincipalFactory>();

            services.AddCors(options => options.AddPolicy("AllowAll", p =>
                p.SetIsOriginAllowed((host) => true).
                  AllowAnyMethod().
                  AllowAnyHeader().
                  AllowCredentials()));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCookiePolicy();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                InitializeDbTestData(app);
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors("AllowAll");

            // app.UseHealthChecks("/health");

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }

        private static void InitializeDbTestData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
                serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>().Database.Migrate();
                serviceScope.ServiceProvider.GetRequiredService<IdentityApplicationDbContext>().Database.Migrate();

                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

                if (!context.Clients.Any())
                {
                    foreach (var client in Clients.Get())
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }
                else
                {
                    // update
                    foreach (var client in Clients.Get())
                    {
                        if (context.Clients.Any(x => x.ClientId == client.ClientId))
                        {
                            continue;
                        }
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var resource in Resources.GetIdentityResources())
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }
                else
                {
                    foreach (var resource in Resources.GetIdentityResources())
                    {
                        if (context.IdentityResources.Any(x => x.Name == resource.Name))
                        {
                            continue;
                        }
                        context.IdentityResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.ApiScopes.Any())
                {
                    foreach (var scope in Resources.GetApiScopes())
                    {
                        context.ApiScopes.Add(scope.ToEntity());
                    }
                    context.SaveChanges();
                }
                else
                {
                    foreach (var scope in Resources.GetApiScopes())
                    {
                        if (context.ApiScopes.Any(x => x.Name == scope.Name))
                        {
                            continue;
                        }
                        context.ApiScopes.Add(scope.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.ApiResources.Any())
                {
                    foreach (var resource in Resources.GetApiResources())
                    {
                        context.ApiResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }
                else
                {
                    foreach (var resource in Resources.GetApiResources())
                    {
                        if (context.ApiResources.Any(x => x.Name == resource.Name)) { continue; }
                        context.ApiResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }

                //var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                //if (!userManager.Users.Any())
                //{
                //    foreach (var testUser in Users.Get())
                //    {
                //        var identityUser = new IdentityUser(testUser.Username)
                //        {
                //            Id = testUser.SubjectId
                //        };

                //        userManager.CreateAsync(identityUser, testUser.Password).Wait();
                //        userManager.AddClaimsAsync(identityUser, testUser.Claims.ToList()).Wait();
                //    }
                //}
            }
        }

    }
}
