using System.Linq;
using NUnit.Framework;

namespace TddStringCalculator
{
    [TestFixture]
    public class Class1 
    {
        [Test]
        public void ICanParseString_AndSumUpValues()
        {
            var input = "1,2,3,4,5";
            var expectedSum = 15;

            var actualSum = new StringCalculator().SumFromString(input);


            Assert.That(actualSum, Is.EqualTo(expectedSum));
        }

        [Test]
        public void IfInputNullEmptyWhiteSpace_Return_0()
        {
            var input = string.Empty;
            var expectedSum = 0;

            var actualSum = new StringCalculator().SumFromString(input);


            Assert.That(actualSum, Is.EqualTo(expectedSum));
        }
    }

    public class StringCalculator
    {
        public object SumFromString(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return 0;

            var values = input.Split(',');
            return values.Select(x => int.Parse(x)).Sum();
        }
    }
}