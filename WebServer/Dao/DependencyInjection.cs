using NOM.Dao.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NOM.Dao
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDaoModule(this IServiceCollection services, IConfiguration configuration)
        {
            var oracleVersion = configuration.GetSection("OracleSettings").GetSection("OracleVersion").Value;
            services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseOracle(
                       configuration.GetConnectionString("DefaultConnection"), b => b.UseOracleSQLCompatibility(oracleVersion)));
            return services;
        }
    }
}
