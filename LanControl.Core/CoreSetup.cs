using Config.Net;
using LanControl.Core.Adapters;
using LanControl.Core.Adapters.Interfaces;
using LanControl.Core.Database;
using LanControl.Shared.Exceptions;
using LanControl.Core.Repositories.Interfaces;
using LanControl.Core.Repositories;
using LanControl.Core.Services;
using LanControl.Core.Services.Interfaces;
using LanControl.Core.Workers;
using LanControl.Shared.ViewModels.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LanControl.Core;

public static class CoreSetup
{
    public static void AddCore(this IServiceCollection serviceCollection)
    {
        var config = new ConfigurationBuilder<IConfig>().UseEnvironmentVariables().UseDotEnvFile().Build();
        serviceCollection.AddSingleton(config);
        serviceCollection.AddSingleton<IMessageQueueService, MessageQueueService>();
        
        serviceCollection.AddScoped<IDiscordWebhookLogService, DiscordWebhookLogService>();
        serviceCollection.AddScoped<ISendDiscordWebhookAdapter, SendDiscordWebhookAdapter>();
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IAuthenticationService, AuthenticationService>();
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddDbContext<DatabaseContext>(options =>
        {
            if(config.DatabaseConnectionString is null) throw new DatabaseException("CONNECTION_STRING_NOT_PROVIDED");
            options.UseSqlite($"Data Source={config.DatabaseConnectionString}");
        });
        
        serviceCollection.AddHttpClient<ISendDiscordWebhookAdapter, SendDiscordWebhookAdapter>();
        serviceCollection.AddHostedService<SendDiscordWebhookWorker>();
    }

}
