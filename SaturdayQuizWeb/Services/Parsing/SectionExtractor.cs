using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using RegexToolbox;
using SaturdayQuizWeb.Model.Parsing;
using SaturdayQuizWeb.Utils;
using RegexOptions = RegexToolbox.RegexOptions;

namespace SaturdayQuizWeb.Services.Parsing
{
    public interface ISectionExtractor
    {
        Sections ExtractSections(string wholePageHtml);
    }

    public class SectionExtractor : ISectionExtractor
    {
        private const int CloseLinesThreshold = 2;

        private static readonly Regex PTagRegex = new RegexBuilder()
            .Text("<p")
            .WordBoundary()
            .AnyCharacterExcept(">", RegexQuantifier.ZeroOrMore)
            .Text(">")
            .BuildRegex(RegexOptions.IgnoreCase);

        private class LineWithNumber
        {
            public int Number { get; set; }
            public string Text { get; set; }
        }


        public Sections ExtractSections(string wholePageHtml)
        {
            var allHtmlLines = wholePageHtml
                .Replace("\n", string.Empty)
                .Replace(PTagRegex, "\n<p>")
                .Replace("</p>", "</p>\n")
                .Split("\n")
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(line => line.Trim());

            var paragraphLines = FindParagraphLines(allHtmlLines);

            var sectionLines = paragraphLines
                .Where(IsSectionLine)
                .ToList();

            if (sectionLines.Count != 2)
            {
                throw new ParsingException($"Found {sectionLines.Count} matching line(s) in source HTML (expected 2)");
            }

            return new Sections
            {
                QuestionsSectionHtml = sectionLines[0],
                AnswersSectionHtml = sectionLines[1]
            };
        }

        private static IEnumerable<string> FindParagraphLines(IEnumerable<string> wholePageHtmlLines)
        {
            var paragraphLines = wholePageHtmlLines
                .Select((line, index) => new LineWithNumber
                {
                    Number = index,
                    Text = line
                })
                .Where(line => line.Text.StartsWith("<p>", StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (paragraphLines.Count < 2)
            {
                throw new ParsingException($"Found {paragraphLines.Count} lines in <p> tags in source HTML (expected at least 2)");
            }

            // Merge lines that are close in the source code
            for (var index = 1; index < paragraphLines.Count; index++)
            {
                // ReSharper disable once InvertIf
                if (AreClose(paragraphLines[index].Number, paragraphLines[index - 1].Number))
                {
                    paragraphLines[index - 1].Text += paragraphLines[index].Text;
                    paragraphLines.RemoveAt(index);
                    index--;
                }
            }

            return paragraphLines.Select(lineWithNumber => lineWithNumber.Text);
        }

        private static bool IsSectionLine(string line)
        {
            var index = 0;
            for (var number = 1; number <= ParsingConstants.MinimumQuestionCount; number++)
            {
                index = line.IndexOf(number.ToString(), index, StringComparison.Ordinal);
                if (index == -1)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool AreClose(int a, int b) => Math.Abs(a - b) < CloseLinesThreshold;
    }
}
