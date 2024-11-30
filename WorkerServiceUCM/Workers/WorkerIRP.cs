using BackgroundServicesUCM.Options;
using BackgroundServicesUCM.Services;

namespace BackgroundServicesUCM.Workers
{
    internal class WorkerIRP : BackgroundService
    {
        private readonly ServiceIRP _serviceIRP;
        private readonly ILogger<WorkerIRP> _logger;
        private readonly OptionIRP _optionIRP = new OptionIRP();

        public WorkerIRP(ILogger<WorkerIRP> logger, IConfiguration configuration)
        {
            _logger = logger;
            _serviceIRP = new ServiceIRP();
            configuration.GetSection("AppOptions:IRP").Bind(_optionIRP);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    if (_logger.IsEnabled(LogLevel.Information))
                        _logger.LogInformation("IRP worker running at: {time}", DateTimeOffset.Now);
                    await _serviceIRP.RunAsync();
                }
                catch (Exception ex)
                {
                    if (_logger.IsEnabled(LogLevel.Error))
                        _logger.LogError("IRP worker got error at: {time}, error: {error}", DateTimeOffset.Now, ex.ToString());
                }
                await Task.Delay(_optionIRP.DataRequestFrequency, stoppingToken);
            }
        }
    }
}