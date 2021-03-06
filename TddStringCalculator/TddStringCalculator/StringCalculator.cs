﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TddStringCalculator
{
    public class StringCalculator
    {
        private readonly Regex DelimeterValueRegex = new Regex("//(?<delimeter>.*)\n(?<value>.*)", RegexOptions.Compiled);

        private readonly Regex SingleDelimeterRegex = new Regex("\\[(.+?)\\]");

        private IEnumerable<string> DefaultDelimiters
        {
            get { return new[] { ",", "\n" }; }
        }

        public int SumFromString(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return 0;

            var extractedData = ExtractDelimeters(input);
            return this.ParseSumValues(extractedData.Item1, extractedData.Item2);
        }

        private int ParseSumValues(IEnumerable<string> delimeters, string input)
        {
            try
            {
                var values = input.Split(delimeters.ToArray(), StringSplitOptions.None).Select(x => int.Parse(x));

                var negativeValues = values.Where(x => x < 0);

                if (negativeValues.Any())
                {
                    throw new ArgumentException(string.Format("values '{0}' not supported", string.Join(",", negativeValues)));
                }

                return values.Where(x => x < 1000).Sum();
            }
            catch (FormatException ex)
            {
                throw new InputStringNotFormatedProperly(string.Format("Unexpected format input - {0}", input), ex);
            }
        }

        private Tuple<IEnumerable<string>, string> ExtractDelimeters(string input)
        {
            var delimeterIndex = input.IndexOf("//");

            var delimeters = new List<string>();

            var extractedInput = input;

            if (delimeterIndex >= 0)
            {
                var matches = DelimeterValueRegex.Matches(input);
                extractedInput = this.ExtractRegexpGroup(matches, "value");

                delimeters = this.ExtractSingleDelimiters(matches);

            }
            else
            {
                delimeters.AddRange(this.DefaultDelimiters);
            }

            return new Tuple<IEnumerable<string>, string>(delimeters, extractedInput);
        }

        private List<string> ExtractSingleDelimiters(MatchCollection matches)
        {
            var delim = this.ExtractRegexpGroup(matches, "delimeter");

            var singleDelims = SingleDelimeterRegex.Matches(delim).OfType<Match>().Select(x => x.Groups[1].Value).ToList();

            if (singleDelims.Any())
            {
                return singleDelims;
            }
            else
            {
                return new List<string> { delim };
            }
        }

        private string ExtractRegexpGroup(MatchCollection regexMatches, string groupName)
        {
            return regexMatches.OfType<Match>().Select(m => m.Groups[groupName].Value).Single();
        }
    }
}
