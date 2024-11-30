using BackgroundServicesUCM.Options;
using BackgroundServicesUCM.Workers;
using DbUCM;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

AppOptions appOptions = new AppOptions();
builder.Configuration.GetSection("AppOptions").Bind(appOptions);

if (appOptions.IRP.RunService)
    builder.Services.AddHostedService<WorkerIRP>();
if (appOptions.KUMA.RunService)
    builder.Services.AddHostedService<WorkerKUMA>();
if (appOptions.IRP.RunService || appOptions.KUMA.RunService)
    builder.Services.AddDbContextPool<AppDbContext>(options => options.UseNpgsql(appOptions.PostgreSQL.ConnectionString));

var host = builder.Build();

host.Run();