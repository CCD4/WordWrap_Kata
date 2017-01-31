using System;
using System.Collections.Generic;
using System.Linq;

namespace WordWrap_Kata
{
    public class WordWrapper
    {
        public static string Umbrechen(string text, int maxZeilenlänge)
        {
            var words = ExtractWords(text);
            words = NormalizeWords(words, maxZeilenlänge);
            var lines = BuildLines(words, maxZeilenlänge);
            var result = AggregateLines(lines);
            return result;
        }

        private static string[] NormalizeWords(string[] words, int maxLineLenght)
        {
            var result = new List<string>();
            foreach (var word in words)
            {
                var wordLength = word.Length;
                if (wordLength <= maxLineLenght)
                {
                    result.Add(word);
                }
                else
                {
                    var lineCount = wordLength / maxLineLenght;
                    for (var i = 0; i < lineCount; i++)
                        result.Add(word.Substring(i * maxLineLenght, maxLineLenght));
                    var rest = wordLength % maxLineLenght;
                    if (rest > 0)
                        result.Add(word.Substring(lineCount * maxLineLenght, rest));
                }
            }
            return result.ToArray();
        }

        private static string[] ExtractWords(string text)
        {
            return text.Split(new[] {" ", Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
        }

        private static string AggregateLines(IEnumerable<string> lines)
        {
            return string.Join(Environment.NewLine, lines);
        }

        private static IEnumerable<string> BuildLines(string[] words, int maxZeilenlänge)
        {
            var lineWords = GroupWordsIntoLines(words, maxZeilenlänge);
            var lines = ConcatWordsIntoLines(lineWords);
            return lines;
        }

        private static IEnumerable<string> ConcatWordsIntoLines(string[][] lineWords)
        {
            return lineWords.Select(lw => string.Join(" ", lw));
        }

        private static string[][] GroupWordsIntoLines(string[] words, int maxLineLength)
        {
            var lines = new List<List<string>>();
            var currentLine = new List<string>();

            foreach (var word in words)
            {
                var wordLength = word.Length;
                var lineLength = currentLine.Sum(w => w.Length + 1);

                var futureLineLength = wordLength + lineLength;
                if (futureLineLength > maxLineLength)
                {
                    lines.Add(currentLine);
                    currentLine = new List<string>();
                }
                currentLine.Add(word);
            }
            if (currentLine.Any())
                lines.Add(currentLine);

            return lines.Select(l => l.ToArray()).ToArray();
        }
    }
}