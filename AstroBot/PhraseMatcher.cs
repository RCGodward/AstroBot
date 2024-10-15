using System.Text.RegularExpressions;

namespace AstroBot
{
    public class PhraseMatcher
    {
        public bool IsMatch(string message)
        {
            return Regex.IsMatch(message, @"\bAstros?\b|\bYankees?\b", RegexOptions.IgnoreCase);
        }
    }
}
