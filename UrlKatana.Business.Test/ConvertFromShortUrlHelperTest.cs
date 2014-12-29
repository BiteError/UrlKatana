using System;
using System.Linq;
using NUnit.Framework;
using UrlKatana.Business.Helpers;

namespace UrlKatana.Business.Test
{
    [TestFixture]
    public class ConvertFromShortUrlHelperTest
    {
        [TestCase("aaaaaaa", (uint)0)]
        [TestCase("baaaaaa", (uint)1)]
        [TestCase("zaaaaaa", (uint)25)]
        [TestCase("0aaaaaa", (uint)26)]
        [TestCase("abaaaaa", (uint)32)]
        [TestCase("aabaaaa", (uint)1024)]
        [TestCase("555555d", uint.MaxValue)]
        public void GetIdTest(string shortUrl, uint expected)
        {
            uint actual = ConvertFromShortUrlHelper.GetId(shortUrl);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("9")]
        [TestCase("'")]
        [TestCase("~")]
        [TestCase("aaa9aa")]
        [TestCase("aaaaaaaa")]
        public void GetIdTestForException(string errorUrl)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ConvertFromShortUrlHelper.GetId(errorUrl));
        }
    }
}
