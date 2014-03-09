using System;
using System.Linq;
using System.Runtime.Serialization;
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

        [Test]
        public void IfInputNotFormatted_throws()
        {
            var input = "1,2,3,4,,,5";

            Assert.Throws<InputStringNotFormatedProperly>(() => new StringCalculator().SumFromString(input));
        }
    }

    [Serializable]
    public class InputStringNotFormatedProperly : Exception
    {
        public InputStringNotFormatedProperly() { } 

        public InputStringNotFormatedProperly(string message) :base(message) { } 

        public InputStringNotFormatedProperly(string message, Exception innerException)
            :base(message, innerException) { }

        public InputStringNotFormatedProperly(SerializationInfo info, StreamingContext context)
            :base(info, context) { }

    }

    public class StringCalculator
    {
        public object SumFromString(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return 0;

            try
            {
                var values = input.Split(',');
                return values.Select(x => int.Parse(x)).Sum();
            }
            catch (FormatException ex)
            {
                throw new InputStringNotFormatedProperly(string.Format("Unexpected format input - {0}", input), ex);
            }
        }
    }
}