using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.ApplicationInsights;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebsiteWatcher.Services;

var builder = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        //services.AddApplicationInsightsTelemetryWorkerService();
       // services.ConfigureFunctionsApplicationInsights();
        services.AddSingleton<PdfCreatorService> ();
    });

var host = builder.Build();
host.Run();
