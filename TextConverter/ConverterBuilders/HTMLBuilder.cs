using System.Collections.Generic;

namespace TextConverter.ConverterBuilders
{
    public class HtmlBuilder : ConverterBuilder
    {
        public override ConverterBuilder AddHeader(string header, HeaderLevels level)
        {
            throw new System.NotImplementedException();
        }

        public override ConverterBuilder AddOrderedList(IEnumerable<string> args)
        {
            throw new System.NotImplementedException();
        }

        public override ConverterBuilder AddBulletedList(IEnumerable<string> args)
        {
            throw new System.NotImplementedException();
        }

        public override ConverterBuilder AddText(string text)
        {
            throw new System.NotImplementedException();
        }

        public override string GetExtension() => ".html";
    }
}
