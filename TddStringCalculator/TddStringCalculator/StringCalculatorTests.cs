using System;
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

        [Test]
        public void Negative_values_not_supported_throws()
        {
            var calculator = new StringCalculator();
            var value = "1,2,-3,-4";

            var ex = Assert.Throws<ArgumentException>(() => calculator.SumFromString(value));
            Assert.That(ex.Message, Is.EqualTo("values '-3,-4' not supported"));
        }

        [Test]
        public void Sum_ignores_number_greater_than_1000()
        {
            var calculator = new StringCalculator();
            var value = "1,2000,1000,1003";

            var actual = calculator.SumFromString(value);

            var expected = 1;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(";;;")]
        [TestCase("x")]
        [TestCase("-----")]
        [TestCase("123456789")]
        [TestCase("              ")]
        [TestCase("\r")]
        [TestCase("()()()")]
        [TestCase("((()))")]
        [TestCase("!@#$%^^&*()_+/|`~")]
        public void MultiCharDelimeter_Is_Supported(string delimiter)
        {
            var calculator = new StringCalculator();
            var value = string.Format("//{0}\n1{0}2{0}3{0}4", delimiter);

            var actual = calculator.SumFromString(value);

            var expected = 10;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Multiple_Delimeters_Test()
        {
            var calculator = new StringCalculator();
            var value = "//[*][%]\n1*2%3";

            var actual = calculator.SumFromString(value);

            var expected = 6;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}