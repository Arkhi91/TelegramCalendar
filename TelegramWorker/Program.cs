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
            builder.Services.AddHostedService<HostedService>();
            builder.Services.AddSingleton(x => 
            {
                return new TelegramBotClient("6218699192:AAGOGW4W2p4nYvvtMaUOmWx8q737ni7GECM");
            });

            var app = builder.Build();
            

            app.UseAuthorization();
            app.Run();
        }
    }
}