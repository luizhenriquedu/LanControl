﻿using Config.Net;
using LanControl.Core.Adapters;
using LanControl.Core.Adapters.Interfaces;
using LanControl.Core.Database;
using LanControl.Core.Repositories.Interfaces;
using LanControl.Core.Services;
using LanControl.Core.Services.Interfaces;
using LanControl.Core.Workers;
using LanControl.Shared.ViewModels.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LanControl.Core;

public static class CoreSetup
{
    public static void AddCore(this IServiceCollection serviceCollection)
    {
        var config = new ConfigurationBuilder<IConfig>().UseEnvironmentVariables().UseDotEnvFile().Build();
        serviceCollection.AddSingleton(config);
        serviceCollection.AddToAspNetDi();
    }

    private static void AddToAspNetDi(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IMessageQueueService, MessageQueueService>();
        serviceCollection.AddScoped<IDiscordWebhookLogService, DiscordWebhookLogService>();
        serviceCollection.AddScoped<ISendDiscordWebhookAdapter, SendDiscordWebhookAdapter>();
        serviceCollection.AddScoped<IUserRepository, IUserRepository>();
        serviceCollection.AddScoped<IAuthenticationService, AuthenticationService>();
        serviceCollection.AddDbContext<DatabaseContext>();
        serviceCollection.AddHostedService<SendDiscordWebhookWorker>();
    }
}
