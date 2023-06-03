using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace TelegramWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddHostedService<TelegramBackgroundService>();
            builder.Services.AddSingleton<ITelegramBotClient>(x => 
            {
                var token = builder.Configuration["TelegramBotToken"];
                return new TelegramBotClient(token);
                
            });

            var app = builder.Build();
            

            app.UseAuthorization();
            app.Run();
        }
    }
}