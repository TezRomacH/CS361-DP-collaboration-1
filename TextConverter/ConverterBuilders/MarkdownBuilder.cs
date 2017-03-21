using System.Collections.Generic;
using System;

namespace TextConverter.ConverterBuilders
{
    public class MarkdownBuilder : ConverterBuilder
    {
        private Dictionary<HeaderLevels, string> headers;

        public MarkdownBuilder()
        {
            headers = new Dictionary<HeaderLevels, string>();
            headers.Add(HeaderLevels.Level1, "#");
            headers.Add(HeaderLevels.Level2, "##");
            headers.Add(HeaderLevels.Level3, "###");
            result = new System.Text.StringBuilder();
        }

        public override ConverterBuilder AddHeader(string header, HeaderLevels level)
        {
            result.AppendFormat(headers[level] + header + headers[level]);
            AddNewLine();
            return this;
        }

        public override ConverterBuilder AddOrderedList(IEnumerable<string> args)
        {
            foreach(var item in args)
            {
                result.AppendFormat($"1. {item}");
                AddNewLine();
            }
            return this;
        }

        public override ConverterBuilder AddBulletedList(IEnumerable<string> args)
        {
            foreach (var item in args)
            {
                result.AppendFormat($"* {item}");
                AddNewLine();
            }
            
            return this;
        }

        public override ConverterBuilder AddText(string text)
        {
            result.Append(text + Environment.NewLine);
            return this;
        }
        

        public override string GetExtension() => ".md";
    }
}
