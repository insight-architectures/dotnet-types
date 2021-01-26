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

            result = default;

            if (!match.Success)
            {
                return false;
            }

            var year = getYear(match.Groups["year"]);
            var month = match.Groups["month"].Value;
            var day = match.Groups["day"].Value;

            if (DateTime.TryParse($"{year}-{month}-{day}", out var date) && int.TryParse(match.Groups["extra"].Value, NumberStyles.None, CultureInfo.InvariantCulture.NumberFormat, out var extra))
            {
                result = new SwedishPersonalNumber(date, extra);
                return true;
            }

            return false;

            static string getYear(Group group)
            {
                var str = group.Value;

                if (str is { Length: 2 })
                {
                    str = $"19{str}";
                }

                return str;
            }
        }
    }
}
