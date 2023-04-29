using Telegram.Bot;

namespace TelegramWorker
{
    public class TelegramBackgroundService : BackgroundService
    {
        ILogger<TelegramBackgroundService> _logger;
        ITelegramBotClient _client;

        public TelegramBackgroundService(ITelegramBotClient client, ILogger<TelegramBackgroundService> logger)
        {
            _logger = logger;
            _client = client;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
        //перенести логику из телеги

    }
}
