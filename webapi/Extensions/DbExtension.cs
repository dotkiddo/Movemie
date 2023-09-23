using DbUp;
using System.Reflection;

namespace webapi.Extensions
{
    // generic class to use with ILogger<T>
    public class ApplicationLogger
    {

    }

    public static class DbExtension
    {
        public static IHost MigrateDb<TContext>(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var config = services.GetRequiredService<IConfiguration>();
                var logger = services.GetRequiredService<ILogger<ApplicationLogger>>();

                logger.LogInformation("Migrating DB");
                                
                string connection = config.GetConnectionString(Resources.Strings.DbName);

                EnsureDatabase.For.SqlDatabase(connection);

                var upgrader = DeployChanges.To.SqlDatabase(connection)
                                               .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                                               .LogToConsole()
                                               .Build();

                var result = upgrader.PerformUpgrade();

                if (!result.Successful)
                {
                    logger.LogError(result.Error, "An error occurred while migrating the DB");
                    return host;
                }

                logger.LogInformation("Successfully Migrated DB");
            }

            return host;
        }
    }
}
