using System;
using NUnit.Framework;
using TextConverter.ConverterBuilders;

namespace TextConverter.UnitTests
{
    [TestFixture]
    public class BuildersTest
    {
        [Test]
        [TestCase(new[] { "one", "two", "three" }, "1. one\r\n1. two\r\n1. three")]
        [TestCase(new[] { "one", "", "two" }, "1. one\r\n1. \r\n1. two")]
        [TestCase(new string[0], "")]
        [TestCase(null, "")]
        public void MarkdouwBuilderOrderesLists_Tests(string[] args, string result)
        {
            var builder = new MarkdownBuilder();
            Assert.That(builder.AddOrderedList(args).ToString(), Is.EqualTo(result));
        }

        [Test]
        public void MarkdouwBuilderLists_Tests()
        {
            var builder = new MarkdownBuilder();
            Assert.That(builder.AddOrderedList(null).ToString(), Is.Empty);

            builder.AddOrderedList(new[] { "1." }).AddBulletedList(new[] { "13" });
            Assert.That(builder, Is.InstanceOf(typeof(MarkdownBuilder)));
            Assert.That(builder.ToString(), Is.EqualTo("1. 1.\r\n*. 13"));

            builder.Clear().AddOrderedList(new[] { "1." }).AddNewLine().AddBulletedList(new[] { "13" });
            Assert.That(builder.ToString(), Is.EqualTo("1. 1.\r\n\r\n*. 13"));
        }

        [Test]
        public void HtmlBuilder_Tests()
        {
            var builder = new HtmlBuilder();
            Assert.That(builder.GetExtension(), Is.EqualTo("html"));

            Assert.That(builder.AddNewLine().ToString(), Is.EqualTo(Environment.NewLine));
            Assert.That(builder.Clear().AddBulletedList(new[]{"423", "132", "end"}), Is.InstanceOf(typeof(HtmlBuilder)));
            Assert.That(builder.ToString(), Does.EndWith("</ul>"));
            Assert.That(builder.ToString(), Does.StartWith("<ul>"));

            Assert.That(builder.AddHeader("dsada", HeaderLevels.Level2).ToString(),
                Is.EqualTo("<ul>\r\n<li>423</li>\r\n<li>132</li>\r\n<li>end</li>\r\n</ul>\r\n<h2>dsada</h2>"));
        }
    }
}
