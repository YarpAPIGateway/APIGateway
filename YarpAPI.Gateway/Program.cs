var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Load YARP configuration
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
//var proxyConfig = builder.Configuration.GetSection("ReverseProxy").GetChildren();
//foreach (var item in proxyConfig)
//{
//    Console.WriteLine(item.Key);
//}
var app = builder.Build();

app.MapReverseProxy();
app.Run();
