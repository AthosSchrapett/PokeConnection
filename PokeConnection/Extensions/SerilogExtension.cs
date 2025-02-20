using Serilog;

namespace PokeConnection.API.Extensions;

public static class SerilogExtension
{
    public static IHostBuilder AddSerilog(this IHostBuilder hostBuilder)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        hostBuilder.ConfigureLogging((context, logging) =>
        {
            logging.AddSerilog();
        });
        return hostBuilder;
    }
}
