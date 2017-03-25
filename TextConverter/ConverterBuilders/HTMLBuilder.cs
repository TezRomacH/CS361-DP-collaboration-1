using System.Collections.Generic;
using System;

namespace TextConverter.ConverterBuilders
{
    public class HtmlBuilder : ConverterBuilder
    {
        public HtmlBuilder()
        {
            result = new System.Text.StringBuilder();
        }

        public override ConverterBuilder AddHeader(string header, HeaderLevels level)
        {
            CheckAddNewLine();
            switch (level)
            {
                case HeaderLevels.Level1:
                    result.AppendFormat($"<h1>{header}</h1>");
                    break;

                case HeaderLevels.Level2:
                    result.AppendFormat($"<h2>{header}</h2>");
                    break;

                case HeaderLevels.Level3:
                    result.AppendFormat($"<h3>{header}</h3>");
                    break;
            }
            return this;
        }

        public override ConverterBuilder AddOrderedList(IEnumerable<string> args)
        {
            CheckAddNewLine();
            result.Append("<ol>" + Environment.NewLine);
            AddListItems(args);
            result.Append("</ol>");
            return this;
        }
        public override ConverterBuilder AddBulletedList(IEnumerable<string> args)
        {
            CheckAddNewLine();
            result.Append("<ul>" + Environment.NewLine);
            AddListItems(args);
            result.Append("</ul>");
            return this;
        }

        private ConverterBuilder AddListItems(IEnumerable<string> args)
        {
            foreach (var item in args)
            {
                result.AppendFormat($"<li>{item}</li>" + Environment.NewLine);
            }
            return this;
        }


        public override ConverterBuilder AddText(string text)
        {
            CheckAddNewLine();
            result.AppendFormat($"<p>{text}</p>");
            return this;
        }

        public override string GetExtension() => "html";
    }
}
