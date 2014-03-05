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

            var values = input.Split(',');

            var actualSum = values.Select(x => int.Parse(x)).Sum();

            Assert.That(actualSum, Is.EqualTo(expectedSum));
        }
    }
}