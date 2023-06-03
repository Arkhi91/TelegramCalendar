using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;


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
            _client.StartReceiving(Update, Error);
        }
        //перенести логику из телеги

        private static Task Error(ITelegramBotClient botClient, Exception ex, CancellationToken token)
        {
            _logger.LogError(ex);
        }

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;
            if (message.Text != null)
            {
                Console.WriteLine($"{message.Chat.FirstName} | {message.Text}");
                if (message.Text.ToLower().Contains("привет"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Привет {username}!");
                }
                else if (message.Text.ToLower().Contains("котик"))
                {
                    var fileName2 = "278428-frederika.jpg";

                    var path = @"C:\Users\Илья\Desktop\278428-frederika.jpg";
                    using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        await botClient.SendDocumentAsync(
                            update.Message.Chat.Id, new InputOnlineFile(fileStream)

                        );
                    }
                    //await botClient.SendDocumentAsync(message.Chat.Id, new InputOnlineFile(fileName2));
                    //stream.Close();
                }
            }
            if (message.Photo != null)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "{username}, я пока не умею работать с фото, скинь мне документом пожалуйста");
            }
            if (message.Document != null)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Вау, супер, щас погоди немного я тебе пришлю ответ!");
                var field = update.Message.Document.FileId;
                var fileInfo = await botClient.GetFileAsync(field);
                var filePath = fileInfo.FilePath;

                string destinationFilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\{message.Document.FileName}";
                await using FileStream fileStream = System.IO.File.OpenWrite(destinationFilePath);
                await botClient.DownloadFileAsync(filePath, fileStream);

                try
                {
                    var path = @"C:\Users\Илья\Desktop\278428-frederika.jpg";
                    await using Stream stream = System.IO.File.OpenRead(path);
                    var fileName2 = "278428-frederika.jpg";
                    await botClient.SendDocumentAsync(message.Chat.Id, new InputOnlineFile(stream, fileName2));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
