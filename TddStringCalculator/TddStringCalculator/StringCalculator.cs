using System;
using System.Linq;

namespace TddStringCalculator
{
    public class StringCalculator
    {
        public int SumFromString(string input)
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