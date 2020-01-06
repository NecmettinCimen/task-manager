using System.Text.RegularExpressions;

namespace TaskManager.Models
{
    public class FriendlyURL
    {
        public static string GetURLFromTitle(string title)
        {
            title = title.Trim().ToLower();
            title = Regex.Replace(title, "ş", "s");
            title = Regex.Replace(title, "ı", "i");
            title = Regex.Replace(title, "ö", "o");
            title = Regex.Replace(title, "ü", "u");
            title = Regex.Replace(title, "ç", "c");
            title = Regex.Replace(title, "ğ", "g");
            title = Regex.Replace(title, @"[^a-z0-9]", " ");
            title = Regex.Replace(title, @"\s+", " ");
            title = title.Trim();
            title = Regex.Replace(title, " ", "-");
            return title;
        }
    }
}