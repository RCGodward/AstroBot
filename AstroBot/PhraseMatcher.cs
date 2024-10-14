using System.Text.RegularExpressions;

namespace AstroBot
{
    public class PhraseMatcher
    {
        public bool IsMatch(string message)
        {
            return Regex.IsMatch(message, "A.*s.*t.*r.*o.?s?", RegexOptions.IgnoreCase);
        }
    }
}
