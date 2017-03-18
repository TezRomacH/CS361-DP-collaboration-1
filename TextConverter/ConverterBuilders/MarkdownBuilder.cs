using System.Collections.Generic;

namespace TextConverter.ConverterBuilders
{
    public class MarkdownBuilder : ConverterBuilder
    {
        public override ConverterBuilder AddHeader(HeaderLevels level, string header)
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

        public override ConverterBuilder AddText(string str)
        {
            throw new System.NotImplementedException();
        }

        public override string GetExtension() => ".md";
    }
}
