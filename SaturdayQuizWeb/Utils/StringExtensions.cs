using System.Text.RegularExpressions;

namespace SaturdayQuizWeb.Utils
{
    public static class StringExtensions
    {
        public static string Replace(this string s, Regex regex, string replacement) => regex.Replace(s, replacement);
    }
}
