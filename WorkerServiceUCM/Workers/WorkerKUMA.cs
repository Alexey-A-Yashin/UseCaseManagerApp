using BackgroundServicesUCM.Options;
using BackgroundServicesUCM.Services;

namespace BackgroundServicesUCM.Workers
{
    internal class WorkerKUMA : BackgroundService
    {
        private readonly ServiceKUMA _serviceKUMA;
        private readonly ILogger<WorkerKUMA> _logger;
        private readonly OptionKUMA _optionKUMA = new OptionKUMA();

        public WorkerKUMA(ILogger<WorkerKUMA> logger, IConfiguration configuration)
        {
            _logger = logger;

            AppOptions appOptions = new AppOptions();
            _serviceKUMA = new ServiceKUMA();
            configuration.GetSection("AppOptions:KUMA").Bind(_optionKUMA);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    if (_logger.IsEnabled(LogLevel.Information))
                        _logger.LogInformation("KUMA worker running at: {time}", DateTimeOffset.Now);
                    await _serviceKUMA.RunAsync();
                }
                catch (Exception ex)
                {
                    if (_logger.IsEnabled(LogLevel.Error))
                        _logger.LogError("KUMA worker got error at: {time}, error: {error}", DateTimeOffset.Now, ex.ToString());
                }

                await Task.Delay(_optionKUMA.DataRequestFrequency, stoppingToken);
            }
        }
    }
}