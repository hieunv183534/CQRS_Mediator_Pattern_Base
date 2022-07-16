using IdentityModel.AspNetCore.OAuth2Introspection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using NOM.Dao;
using NOM.Domain;

//using NOM.Domain.Models;
using NOM.WebApi.Filters;
using NOM.WebApi.Middleware;
using System;

var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration = builder.Configuration;
var services = builder.Services;

// Add services to the container.
// ConfigureServices method

//var emailConfig = Configuration.GetSection("EmailConfiguration").Get<EmailConfigurationModel>();
//services.AddSingleton(emailConfig);

services.ConfigureNonBreakingSameSiteCookies();
services.AddDaoModule(Configuration);
services.AddDomainModule(Configuration);

services.AddHttpContextAccessor();

//services.AddHealthChecks()
//    .AddDbContextCheck<ApplicationDbContext>();

services.AddControllersWithViews(options =>
{
    //options.Filters.Add(new ApiExceptionFilter(Configuration));
    if (Configuration.GetValue<bool>("Login"))
    {
        var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
        options.Filters.Add(new AuthorizeFilter(policy));
    }
})
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
});

services.AddRazorPages();

services.AddAuthentication(options =>
{
    // Identity made Cookie authentication the default.
    // However, we want JWT Bearer Auth to be the default.
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddIdentityServerAuthentication(JwtBearerDefaults.AuthenticationScheme, options =>
{
    options.ApiName = "api1";
    options.Authority = Configuration.GetValue<string>("Authority");
    options.RequireHttpsMetadata = Configuration.GetValue<bool>("RequireHttpsMetadata");
    options.TokenRetriever = new Func<HttpRequest, string>(req =>
    {
        var fromHeader = TokenRetrieval.FromAuthorizationHeader();
        var fromQuery = TokenRetrieval.FromQueryString();
        return fromHeader(req) ?? fromQuery(req);
    });
});

// Add link police for sofware
services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build();

    //options.AddPolicy("default", policy => policy.Requirements.Add(new CustomPolice("default")));
    options.AddPolicy("link", policy => policy.Requirements.Add(new CustomPolice("link")));
    options.AddPolicy("local", policy => policy.Requirements.Add(new CustomPolice("local")));
});

// Customise default API behaviour
services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = false;
});

// In production, the Angular files will be served from this directory
//services.AddSpaStaticFiles(configuration =>
//{
//    configuration.RootPath = "wwwroot/main";
//});

// apply all cors call api
services.AddCors(options => options.AddPolicy("AllowAll", p =>
   p.SetIsOriginAllowed((host) => true).
     AllowAnyMethod().
     AllowAnyHeader().
     AllowCredentials()));

//services.AddOpenApiDocument(configure =>
//{
//    configure.Title = "BCCP API";
//    configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
//    {
//        Type = OpenApiSecuritySchemeType.ApiKey,
//        Name = "Authorization",
//        In = OpenApiSecurityApiKeyLocation.Header,
//        Description = "Type into the textbox: Bearer {your JWT token}."
//    });

//    configure.SchemaNameGenerator = new SchemaNameGenerator();
//    configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
//});

services.AddMemoryCache();

services.AddSwaggerGen();

services.AddTransient<ExceptionHandlingMiddleware>();

//services.AddScoped<IAuthorizationHandler, CustomPoliceHandler>();

// ====================================================

var app = builder.Build();
IWebHostEnvironment env = app.Environment;

// Configure the HTTP request pipeline.
// Configure method
app.UseCookiePolicy();

if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseDatabaseErrorPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    //app.UseExceptionHandler("/api/error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
    //app.UseHttpsRedirection();
}
// haitc 20220524 - handle exception
app.UseExceptionHandling();

app.UseCors("AllowAll");

//app.UseHealthChecks("/health");

app.UseStaticFiles(new StaticFileOptions()
{
    OnPrepareResponse = context =>
    {
        if (context.File.Name == "index.html")
        {
            context.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
            context.Context.Response.Headers.Add("Expires", "-1");
        }
        else
        {
            context.Context.Response.Headers[HeaderNames.CacheControl] = "public,max-age=3600";
        }
    }
});

//if (!env.IsDevelopment())
//{
//    app.UseSpaStaticFiles();
//}

//app.UseSwaggerUi3(settings =>
//{
//    settings.Path = "/api";
//    settings.DocumentPath = "/api/specification.json";
//});

app.UseRouting();

// Configure hangfire to use the new JobActivator we defined.
//GlobalConfiguration.Configuration
//    .UseActivator(new HangfireActivator(serviceProvider));
//app.UseHangfireServer();
//app.UseHangfireDashboard("/hangfire", new DashboardOptions
//{
//    //Authorization = new[] { new HangfireDashboardAuthorizationFilter() }
//});

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
    //endpoints.MapHealthChecks("/health");
    endpoints.MapRazorPages();
    //endpoints.MapHangfireDashboard();
    //endpoints.MapHub<SignalRHub>("/realTime");
});

//app.UseSpa(spa =>
//{
//    // To learn more about options for serving an Angular SPA from ASP.NET Core,
//    // see https://go.microsoft.com/fwlink/?linkid=864501
//    spa.Options.SourcePath = "wwwroot/main";
//});

//app.UseSwagger();
//app.UseSwaggerUi();
app.UseStatusCodePages();

//====================================================
//            //using (var scope = host.Services.CreateScope())
//            //{
//                //var services = scope.ServiceProvider;

//                //try
//                //{
//                //    var context = services.GetRequiredService<ApplicationDbContext>();

//                //    if (context.Database.IsSqlServer())
//                //    {
//                //        context.Database.Migrate();
//                //    }
//                //}
//                //catch (Exception ex)
//                //{
//                //    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

//                //    logger.LogError(ex, "An error occurred while migrating or seeding the database.");

//                //    throw;
//                //}
//            //}

app.Run();