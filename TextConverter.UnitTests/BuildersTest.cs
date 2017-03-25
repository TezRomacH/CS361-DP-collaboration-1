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
            Assert.That(builder.ToString(), Is.EqualTo("1. 1.*. 13"));

            builder.Clear().AddOrderedList(new[] { "1." }).AddNewLine().AddBulletedList(new[] { "13" });
            Assert.That(builder.ToString(), Is.EqualTo("1. 1.\r\n*. 13"));
        }
    }
}
