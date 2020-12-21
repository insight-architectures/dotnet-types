using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.RegularExpressions;

namespace InsightArchitectures.Types
{
    public partial record SwedishPersonalNumber
    {
        private static readonly Regex _personalNumberRegex = new Regex(@"^(?<year>(\d{2})?(\d{2}))\-?(?<month>\d{2})\-?(?<day>\d{2})[\-\+]?(?<extra>\d{4})$", RegexOptions.Compiled);

        /// <summary>
        /// Tries to parse a string into a Swedish personal number.
        /// </summary>
        /// <param name="input">The string to parse.</param>
        /// <param name="result">The result of the operation.</param>
        /// <returns><c>True</c> if the parsing was successful.</returns>
        public static bool TryParse(string input, [NotNullWhen(true)] out SwedishPersonalNumber? result)
        {
            _ = input ?? throw new ArgumentNullException(nameof(input));

            var match = _personalNumberRegex.Match(input);

            if (!match.Success)
            {
                result = default;
                return false;
            }

            var year = getYear(match.Groups["year"]);
            var month = int.Parse(match.Groups["month"].Value, CultureInfo.InvariantCulture.NumberFormat);
            var day = int.Parse(match.Groups["day"].Value, CultureInfo.InvariantCulture.NumberFormat);
            var extra = int.Parse(match.Groups["extra"].Value, CultureInfo.InvariantCulture.NumberFormat);

            result = new SwedishPersonalNumber(new DateTime(year, month, day), extra);
            return true;

            static int getYear(Group group)
            {
                var str = group.Value;

                if (str is { Length: 2 })
                {
                    str = $"19{str}";
                }

                return int.Parse(str, CultureInfo.InvariantCulture.NumberFormat);
            }
        }
    }
}
