using System.Collections.Generic;
using RegexToolbox;

namespace SaturdayQuizWeb.Utils
{
    public static class RegexBuilderExtensions
    {
        private static readonly IEnumerable<string> HtmlWhitespaceCharacters = new[] {" ", @"\t", @"\n", @"\r", "&nbsp;"};

        public static RegexBuilder PossibleHtmlWhitespace(this RegexBuilder regexBuilder) =>
            regexBuilder.AnyOf(HtmlWhitespaceCharacters, RegexQuantifier.ZeroOrMore);
    }
}
