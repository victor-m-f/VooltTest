using Microsoft.Extensions.DependencyInjection;
using VooltTest.Domain.Services.BlockRepository;

namespace VooltTest.Data.Configuration;

public static class DataConfiguration
{
    public static void AddData(this IServiceCollection services)
    {
        services.AddSingleton<IBlockRepository, BlockRepository>();
    }
}
