using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace WebsiteWatcher.Functions;

public class Register(ILogger<Register> _logger)
{
    [Function("Register")]
    [SqlOutput("dbo.Websites", "WebsiteWatcher")]
    public async Task<Website> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        var newWebsite = JsonSerializer.Deserialize<Website>(requestBody, options);

        newWebsite.Id = Guid.NewGuid();

        return newWebsite;
    }
}

public class Website
{
    public Guid Id { get; set; }
    public string Url { get; set; }
    public string? XPathExpression { get; set; }
}
