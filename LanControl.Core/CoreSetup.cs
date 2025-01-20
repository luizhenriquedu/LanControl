using LanControl.Core.Adapters;
using LanControl.Core.Adapters.Interfaces;
using LanControl.Core.Database;
using LanControl.Core.Models;
using LanControl.Core.Services;
using LanControl.Core.Services.Interfaces;
using LanControl.Core.Workers;
using LanControl.Shared.Exceptions;
using LanControl.Shared.ViewModels.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TakasakiStudio.Lina.AutoDependencyInjection;
using TakasakiStudio.Lina.Database;
using TakasakiStudio.Lina.Utils.LoaderConfig;

namespace LanControl.Core;

public static class CoreSetup
{
    public static void AddCore(this IServiceCollection serviceCollection)
    {
        var config = serviceCollection.AddLoaderConfig<IConfig>();
        serviceCollection.AddAutoDependencyInjection<User>();
        serviceCollection.AddSingleton<IMessageQueueService, MessageQueueService>();
        serviceCollection.AddHostedService<SendDiscordWebhookWorker>();
        serviceCollection.AddLinaDbContext<DesignDatabaseContext>((builder, assembly) =>
        {
            builder.UseSqlite("Data Source=../LanControl.Core/Database/Database.db", optionsBuilder =>
            {
                optionsBuilder.MigrationsAssembly(assembly);
            });
        });
        
        serviceCollection.AddHttpClient<ISendDiscordWebhookAdapter, SendDiscordWebhookAdapter>();
        
    }

}
