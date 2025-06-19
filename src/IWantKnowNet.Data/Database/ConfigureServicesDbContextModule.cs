using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IWantKnowNet.Data.Database;

public static class ConfigureServicesDbContextModule
{
    public static IServiceCollection AddDbContextSetting(
        this IServiceCollection services, string connectionString)
    {
        // DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new();
        // optionsBuilder
        //     .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()))
        //     .UseSqlServer(connectionString)
        //     .EnableSensitiveDataLogging();
        //
        // var pool = new DbContextPool<ApplicationDbContext>(optionsBuilder.Options);
        // var dbContextFactory = new PooledDbContextFactory<ApplicationDbContext>(pool);
        //
        // return services.AddSingleton(dbContextFactory);
        
        // builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(options =>
        // {
        //     options.UseSqlServer(connectionString).EnableServiceProviderCaching(false);
        // });

        return services.AddDbContext<ApplicationDbContext>(options =>
        {
            options
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));
            options.UseMySQL(connectionString!);
            options.EnableSensitiveDataLogging();
        });
    }
}