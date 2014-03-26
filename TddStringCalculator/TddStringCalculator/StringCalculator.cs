﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TddStringCalculator
{
    public class StringCalculator
    {
        public int SumFromString(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return 0;

            var delimeterIndex = input.IndexOf("//");

            var delimeters = new List<char>();

            if (delimeterIndex >= 0)
            {
                delimeters.Add(input[delimeterIndex + 2]);
                input = input.Substring(4);
            }
            else
            {
                delimeters.Add(',');
                delimeters.Add('\n');
            }

            try
            {
                var values = input.Split(delimeters.ToArray());
                return values.Select(x => int.Parse(x)).Sum();
            }
            catch (FormatException ex)
            {
                throw new InputStringNotFormatedProperly(string.Format("Unexpected format input - {0}", input), ex);
            }
        }
    }
}