using RegexToolbox;

namespace SaturdayQuizWeb.Utils
{
    public static class RegexBuilderExtensions
    {
        public static RegexBuilder PossibleHtmlWhitespace(this RegexBuilder regexBuilder) =>
            regexBuilder.AnyOf(new []{" ", "\\t", "\\n", "\\r", "&nbsp;"}, RegexQuantifier.ZeroOrMore);
    }
}