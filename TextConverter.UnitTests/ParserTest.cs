using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TextConverter.Parser;
using TextConverter.ConverterBuilders;

namespace TextConverter.UnitTests
{
    [TestFixture]
    public class ParserTest
    {
        [Test]
        public void ParserParse_Test()
        {
            var parser = new Parser.Parser();

            Assert.That(parser.Parse(""), Is.EqualTo(null));
            
            Assert.That(parser.Parse("h1 header"), Is.EqualTo(new List<Tuple<string, string>>()
                { new Tuple<string, string>(KeyWords.Header1, "header") } ));
            
            Assert.That(parser.Parse("h2   header"), Is.EqualTo(new List<Tuple<string, string>>()
                { new Tuple<string, string>(KeyWords.Header2, "  header") } ));

            Assert.That(parser.Parse("h2 header\r\n\r\np text"), 
                Is.EqualTo(new List<Tuple<string, string>>()
                {
                    new Tuple<string, string>(KeyWords.Header2, "header"),
                    new Tuple<string, string>(KeyWords.Text, "text")
                } ));

            Assert.That(parser.Parse("h2 header\r\n\r\np text\r\n\r\nignore text"), 
                Is.EqualTo(new List<Tuple<string, string>>()
                {
                    new Tuple<string, string>(KeyWords.Header2, "header"),
                    new Tuple<string, string>(KeyWords.Text, "text"),
                    new Tuple<string, string>(null, "ignore text")
                } ));

            Assert.That(parser.Parse("ordlist sometext\r\none\r\ntwo"),
                Is.EqualTo(new List<Tuple<string, string>>()
                { new Tuple<string, string>(KeyWords.OrderedList, "sometext\r\none\r\ntwo") } ));

        }

        [Test]
        public void ParserConvertHtml_Test()
        {
            var builder = new HtmlBuilder();
            var parser = new Parser.Parser();

            Assert.That(parser.Convert(builder, ""), Is.EqualTo(""));
            Assert.That(parser.Convert(builder.Clear(), "h1Not header"), Is.EqualTo(""));
            Assert.That(parser.Convert(builder.Clear(), "h1 header"), Is.EqualTo("<h1>header</h1>\r\n"));
            Assert.That(parser.Convert(builder.Clear(), "h1   header"), Is.EqualTo("<h1>  header</h1>\r\n"));
            Assert.That(parser.Convert(builder.Clear(), "ignore this"), Is.EqualTo(""));
            Assert.That(parser.Convert(builder.Clear(), "p text bullist not actually bullist"), Is.EqualTo("<p>text bullist not actually bullist</p>\r\n"));
            Assert.That(parser.Convert(builder.Clear(), "bullist one two"), Is.EqualTo("<ul>\r\n</ul>\r\n"));
            Assert.That(parser.Convert(builder.Clear(), "bullist \r\none\r\ntwo"), Is.EqualTo("<ul>\r\n<li>one</li>\r\n<li>two</li>\r\n</ul>\r\n"));
            Assert.That(parser.Convert(builder.Clear(), "ordlist \r\none\r\ntwo"), Is.EqualTo("<ol>\r\n<li>one</li>\r\n<li>two</li>\r\n</ol>\r\n"));
            Assert.That(parser.Convert(builder.Clear(), "h1 header\r\n\r\np text"), Is.EqualTo("<h1>header</h1>\r\n\r\n<p>text</p>\r\n"));
        }


        [Test]
        public void ParserConvertMarkDown_Test()
        {
            var builder = new MarkdownBuilder();
            var parser = new Parser.Parser();

            Assert.That(parser.Convert(builder, ""), Is.EqualTo(""));
            Assert.That(parser.Convert(builder.Clear(), "h1Not header"), Is.EqualTo(""));
            Assert.That(parser.Convert(builder.Clear(), "h1 header"), Is.EqualTo("# header #\r\n"));
            Assert.That(parser.Convert(builder.Clear(), "h1   header"), Is.EqualTo("#   header #\r\n"));
            Assert.That(parser.Convert(builder.Clear(), "ignore this"), Is.EqualTo(""));
            Assert.That(parser.Convert(builder.Clear(), "p text bullist not actually bullist"), Is.EqualTo("text bullist not actually bullist\r\n"));
            Assert.That(parser.Convert(builder.Clear(), "bullist one two"), Is.EqualTo("\r\n"));
            Assert.That(parser.Convert(builder.Clear(), "bullist \r\none\r\ntwo"), Is.EqualTo("* one\r\n* two\r\n"));
            Assert.That(parser.Convert(builder.Clear(), "ordlist \r\none\r\ntwo"), Is.EqualTo("1. one\r\n1. two\r\n"));
            Assert.That(parser.Convert(builder.Clear(), "h1 header\r\n\r\np text"), Is.EqualTo("# header #\r\n\r\ntext\r\n"));

        }

    }
}
