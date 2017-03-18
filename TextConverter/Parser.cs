using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextConverter.ConverterBuilders;

namespace TextConverter
{
    public class Parser
    {
        public string Parse(ConverterBuilder builder, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";

            foreach (string block in text.Split(new[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                var innerList = block.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                var keyWord = innerList[0].Trim().Split(' ')[0];

                int substringIndex = Math.Min(keyWord.Length + 1, block.Length);
                switch (keyWord)
                {
                    case KeyWords.Text:
                        builder.AddText(block.Substring(substringIndex));
                        break;

                    case KeyWords.Header1:
                        builder.AddHeader(block.Substring(substringIndex), HeaderLevels.Level1);
                        break;
                    case KeyWords.Header2:
                        builder.AddHeader(block.Substring(substringIndex), HeaderLevels.Level2);
                        break;
                    case KeyWords.Header3:
                        builder.AddHeader(block.Substring(substringIndex), HeaderLevels.Level3);
                        break;

                    case KeyWords.OrderedList:
                        builder.AddOrderedList(innerList.Skip(1));
                        break;
                    case KeyWords.BulletedList:
                        builder.AddBulletedList(innerList.Skip(1));
                        break;

                    default:
                        break;
                }
            }

            return builder.ToString();
        }

    }
    public static class KeyWords
    {
        public const string Text = "p";

        public const string Header1 = "h1";
        public const string Header2 = "h2";
        public const string Header3 = "h3";

        public const string OrderedList = "ordlist";
        public const string BulletedList = "bullist";
    }
}
