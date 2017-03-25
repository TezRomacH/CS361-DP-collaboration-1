using System.Collections.Generic;
using System;
using System.Linq;

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
            return this;
        }

        public override ConverterBuilder AddOrderedList(IEnumerable<string> args)
        {
            if (args == null)
                return this;

            // TODO: should we use only Take/Skip/Count methods of IEnumerable?
            var items = args as IList<string> ?? args.ToList();
            int i = 0;
            foreach (var item in items)
            {
                result.AppendFormat($"1. {item}");
                if (++i != items.Count)
                    AddNewLine();
            }
            return this;
        }

        public override ConverterBuilder AddBulletedList(IEnumerable<string> args)
        {
            if (args == null)
                return this;

            // TODO: should we use only Take/Skip/Count methods of IEnumerable?
            var items = args as IList<string> ?? args.ToList();
            int i = 0;
            foreach (var item in items)
            {
                result.AppendFormat($"*. {item}");
                if (++i != items.Count)
                    AddNewLine();
            }
            return this;
        }

        public override ConverterBuilder AddText(string text)
        {
            result.Append(text);
            return this;
        }


        public override string GetExtension() => "md";
    }
}
