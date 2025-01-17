using Config.Net;
using LanControl.Core.Database;
using LanControl.Shared.ViewModels.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LanControl.Core;

public static class CoreSetup
{
    public static void AddCore(this IServiceCollection serviceCollection)
    {
        var config = new ConfigurationBuilder<IConfig>().UseEnvironmentVariables().UseDotEnvFile().Build();
        serviceCollection.AddSingleton(config);
        serviceCollection.AddDbContext<DatabaseContext>();
    }
}
