using NUnit.Framework;

namespace TddStringCalculator
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private StringCalculator stringCalculator;

        [SetUp]
        public void SetUp()
        {
            stringCalculator = new StringCalculator();
        }

        [Test]
        public void ICanParseString_AndSumUpValues()
        {
            var input = "1,2,3,4,5";
            var expectedSum = 15;

            int actualSum = stringCalculator.SumFromString(input);


            Assert.That(actualSum, Is.EqualTo(expectedSum));
        }

        [Test]
        public void IfInputNullEmptyWhiteSpace_Return_0()
        {
            var input = string.Empty;
            var expectedSum = 0;

            int actualSum = stringCalculator.SumFromString(input);


            Assert.That(actualSum, Is.EqualTo(expectedSum));
        }

        [Test]
        public void Newline_character_treated_as_delimeter()
        {
            var input = "1\n2,3\n4";
            var expectedSum = 10;

            int actualSum = stringCalculator.SumFromString(input);


            Assert.That(actualSum, Is.EqualTo(expectedSum));
        }

        [Test]
        public void Support_parametrisied_delimeter()
        {
            var input = "//;\n1;2;3;4";
            var expectedSum = 10;

            int actualSum = stringCalculator.SumFromString(input);


            Assert.That(actualSum, Is.EqualTo(expectedSum));
        }

        [Test]
        public void IfInputNotFormatted_throws()
        {
            var input = "1,2,3,4,,,5";

            Assert.Throws<InputStringNotFormatedProperly>(() => stringCalculator.SumFromString(input));
        }
    }
}