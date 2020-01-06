using System.Net.Http;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class TelegramBot
    {
        public static void Send(string msg)
        {
            var result = new HttpClient()
                .GetAsync($"https://taskmanagerbotapi.necmettincimen.com/?msg={msg} # Necmettin").Result.Content;
        }

        public static async Task SendAsync(string msg)
        {
            await new HttpClient().GetAsync($"https://taskmanagerbotapi.necmettincimen.com/?msg={msg} # Necmettin");
        }
    }
}