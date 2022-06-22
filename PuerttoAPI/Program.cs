using PuerttoAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
var hostBuilder = Host.CreateDefaultBuilder(args);
startup.ConfigureServices(builder.Services, hostBuilder);



var app = builder.Build();
startup.Configure(app, builder.Environment);

app.Run();



