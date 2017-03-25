using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextConverter.ConverterBuilders;

namespace TextConverter.Parser
{
    public class Parser
    {
        private List<Tuple<string, string>> blocks;

        public List<Tuple<string, string>> Parse(string text)
        {
            
            if (string.IsNullOrWhiteSpace(text))
                return null;

            blocks = new List<Tuple<string, string>>();

            foreach (string block in text.Split(new[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                var innerList = block.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                string firstString = innerList[0].Trim();
                var keyWord = firstString.Split(' ')[0];

                int  substringIndex = KeyWords.IsArrayKeyword(keyWord) && firstString == keyWord ?
                    innerList[0].Length :
                    Math.Min(keyWord.Length + 1, block.Length);

                if (KeyWords.IsKeyword(keyWord))
                    blocks.Add(new Tuple<string, string>(keyWord, block.Substring(substringIndex)));
                else
                    blocks.Add(new Tuple<string, string>(null, block));
           
            }

            return blocks;
        }

        public string Convert(ConverterBuilder builder, string text)
        {
            Parse(text);
            if (blocks == null)
                return "";

            foreach(var block in blocks)
            {
                var keyWord = block.Item1;
                var textBlock = block.Item2;
                var innerList = textBlock.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                var isCorrectKeyword = true;

                switch (keyWord)
                {
                    case KeyWords.Text:
                        builder.AddText(textBlock);
                        break;

                    case KeyWords.Header1:
                        builder.AddHeader(textBlock, HeaderLevels.Level1);
                        break;
                    case KeyWords.Header2:
                        builder.AddHeader(textBlock, HeaderLevels.Level2);
                        break;
                    case KeyWords.Header3:
                        builder.AddHeader(textBlock, HeaderLevels.Level3);
                        break;

                    case KeyWords.OrderedList:
                        builder.AddOrderedList(innerList.Skip(1));
                        break;
                    case KeyWords.BulletedList:
                        builder.AddBulletedList(innerList.Skip(1));
                        break;

                    default:
                        isCorrectKeyword = false;
                        break;
                }
                if (isCorrectKeyword)
                    builder.AddNewLine();
            }

            return builder.ToString();
        }
    }
}
