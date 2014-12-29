using System;
using System.Linq;
using NUnit.Framework;
using UrlKatana.Business.Helpers;

namespace UrlKatana.Business.Test
{
    [TestFixture]
    public class ConvertToShortUrlHelperTest
    {
        [TestCase(uint.MinValue, "aaaaaaa")]
        [TestCase((uint)1, "baaaaaa")]
        [TestCase((uint)25, "zaaaaaa")]
        [TestCase((uint)26, "0aaaaaa")]
        [TestCase((uint)31, "5aaaaaa")]
        [TestCase((uint)32, "abaaaaa")]
        [TestCase(uint.MaxValue, "555555d")]
        public void GetShortUrlTest(uint value, string expected)
        {
            var actual = ConvertToShortUrlHelper.GetShortUrl(value);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
