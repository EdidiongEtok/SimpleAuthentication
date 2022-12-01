using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using SimpleAuthenticationData.DbContext;

namespace SimpleAuthentication.ContextFactory
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.Development.json", reloadOnChange: true, optional: true)
            .AddEnvironmentVariables()
            .Build();

            var builder = new DbContextOptionsBuilder<AppDbContext>()
                .UseNpgsql(config.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("SimpleAuthentication"));
            return new AppDbContext(builder.Options);
        }
    }
}
