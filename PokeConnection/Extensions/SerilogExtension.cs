using Elastic.Channels;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Ingest.Elasticsearch;
using Elastic.Serilog.Sinks;
using Elastic.Transport;
using Serilog;

namespace PokeConnection.API.Extensions;

public static class SerilogExtension
{
    public static IHostBuilder AddSerilog(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureLogging((context, logging) =>
        {
            var configuration = context.Configuration;

            Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .WriteTo.Console()
            .WriteTo.Elasticsearch([new Uri("https://localhost:9200")], opts =>
            {
                opts.DataStream = new DataStreamName("logs", "pokeconnection", "dev");
                opts.BootstrapMethod = BootstrapMethod.Failure;
                opts.ConfigureChannel = channelOpts =>
                {
                    channelOpts.BufferOptions = new BufferOptions
                    {
                        ExportMaxRetries = 3,
                        InboundBufferMaxSize = 1000
                    };
                };
            }, transport =>
            {
                transport.Authentication(new BasicAuthentication("elastic", "U24efQYc7904d9zcvh_j"));
                transport.ServerCertificateValidationCallback((sender, certificate, chain, sslPolicyErrors) => true);
            })
            .CreateLogger();

            logging.AddSerilog();
        });

        return hostBuilder;
    }
}
