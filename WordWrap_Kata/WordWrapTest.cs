using System;
using NUnit.Framework;

namespace WordWrap_Kata
{
    [TestFixture]
    public class WordWrapTest
    {
        [Test]
        public void TestWordWrap()
        {
            string input = @"Es blaut die Nacht,
die Sternlein blinken,
Schneeflöcklein leis hernieder sinken.";
            string expected = @"Es blaut
die
Nacht,
die
Sternlein
blinken,
Schneeflö
cklein
leis
hernieder
sinken.";
            var actual = WordWrapper.Umbrechen(input, 9);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestWordWrap2()
        {
            string input = @"The  quick brown!  fox!";
            string expected = @"The quick" + Environment.NewLine + "brown! fox!";
            var actual = WordWrapper.Umbrechen(input, 11);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestWordWrap3()
        {
            string input = @"Line1 L ine2";
            string expected = @"Line1 L" + Environment.NewLine + "ine2";
            var actual = WordWrapper.Umbrechen(input, 7);
            Assert.AreEqual(expected, actual);
        }
    
    }
}