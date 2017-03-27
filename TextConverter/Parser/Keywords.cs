using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextConverter.Parser
{
    /// <summary>
    /// Ключевые слова для парсера
    /// </summary>
    public static class KeyWords
    {
        public const string Text = "p";

        public const string Header1 = "h1";
        public const string Header2 = "h2";
        public const string Header3 = "h3";

        public const string OrderedList = "ordlist";
        public const string BulletedList = "bullist";

        public static readonly IReadOnlyList<string> All = new List<string> { Text, Header1, Header2, Header3, OrderedList, BulletedList };

        public static bool IsKeyword(this string word)
        {
            return All.Contains(word);
        }

        public static bool IsArrayKeyword(this string word)
        {
            List<string> keywords = new List<string> { OrderedList, BulletedList };
            return keywords.Contains(word);
        }
    }
}
