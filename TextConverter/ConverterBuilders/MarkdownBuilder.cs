using System.Collections.Generic;
using System;

namespace TextConverter.ConverterBuilders
{
    public class MarkdownBuilder : ConverterBuilder
    {
        
        public MarkdownBuilder()
        {
            result = new System.Text.StringBuilder();
        }

        public override ConverterBuilder AddHeader(string header, HeaderLevels level)
        {
            switch (level)
            {
                case HeaderLevels.Level1:
                    result.AppendFormat($"# {header} #");
                    break;

                case HeaderLevels.Level2:
                    result.AppendFormat($"## {header} ##");
                    break;

                case HeaderLevels.Level3:
                    result.AppendFormat($"### {header} ###");
                    break;
            }

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
