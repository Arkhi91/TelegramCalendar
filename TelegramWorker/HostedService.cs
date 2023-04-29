namespace TelegramWorker
{
    public class HostedService : IHostedService
    {
        ILogger<HostedService> _logger;

        public HostedService(ILogger<HostedService> logger)
        {
            _logger = logger;
        }
        
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Hosted service is started!");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Hosted service is finished");
            return Task.CompletedTask;
        }
    }
}
