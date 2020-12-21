using System;

namespace InsightArchitectures.Types
{
    /// <summary>
    /// An abstract class that represents the different ways to formatter a Swedish personal number as a string.
    /// </summary>
    public abstract class SwedishPersonalNumberFormatter
    {
        /// <summary>
        /// Formats the <paramref name="personalNumber"/> according to the specified concrete implementation.
        /// </summary>
        /// <param name="personalNumber">The Swedish personal number to formatter as string.</param>
        /// <returns>The string formatted according to the concrete implementation.</returns>
        public abstract string Format(SwedishPersonalNumber personalNumber);

        /// <summary>
        /// A formatter that formats a <see cref="SwedishPersonalNumber" /> using the formatter <c>yyyyMMdd-xxxx</c>.
        /// </summary>
        public static readonly SwedishPersonalNumberFormatter TwelveDigits = new TwelveDigitsSwedishPersonalNumberFormatter();

        /// <summary>
        /// A formatter that formats a <see cref="SwedishPersonalNumber" /> using the formatter <c>yyMMdd-xxxx</c>.
        /// </summary>
        public static readonly SwedishPersonalNumberFormatter TenDigits = new TenDigitsSwedishPersonalNumberFormatter();

        /// <summary>
        /// A formatter that formats a <see cref="SwedishPersonalNumber" /> using the formatter <c>yyyyMMddxxxx</c>.
        /// </summary>
        public static readonly SwedishPersonalNumberFormatter NoSplitTwelveDigits = new NoSplitTwelveDigitsSwedishPersonalNumberFormatter();

        /// <summary>
        /// A formatter that formats a <see cref="SwedishPersonalNumber" /> using the formatter <c>yyMMddxxxx</c>.
        /// </summary>
        public static readonly SwedishPersonalNumberFormatter NoSplitTenDigits = new NoSplitTenDigitsSwedishPersonalNumberFormatter();

        /// <summary>
        /// A formatter that formats a <see cref="SwedishPersonalNumber" /> using the formatter <c>yyyy-MM-dd-xxxx</c>.
        /// </summary>
        public static readonly SwedishPersonalNumberFormatter SplitTwelveDigits = new SplitTwelveDigitsSwedishPersonalNumberFormatter();

        /// <summary>
        /// A formatter that formats a <see cref="SwedishPersonalNumber" /> using the formatter <c>yy-MM-dd-xxxx</c>.
        /// </summary>
        public static readonly SwedishPersonalNumberFormatter SplitTenDigits = new SplitTenDigitsSwedishPersonalNumberFormatter();
    }

    /// <summary>
    /// Formats a Swedish personal number using the formatter yyyyMMddxxxx.
    /// </summary>
    public class NoSplitTwelveDigitsSwedishPersonalNumberFormatter : SwedishPersonalNumberFormatter
    {
        /// <inheritdoc/>
        public override string Format(SwedishPersonalNumber pn)
        {
            _ = pn ?? throw new ArgumentNullException(nameof(pn));

            return $"{pn.DateOfBirth:yyyyMMdd}{pn.OrdinalNumber:0000}";
        }
    }

    /// <summary>
    /// Formats a Swedish personal number using the formatter yyMMddxxxx.
    /// </summary>
    public class NoSplitTenDigitsSwedishPersonalNumberFormatter : SwedishPersonalNumberFormatter
    {
        /// <inheritdoc/>
        public override string Format(SwedishPersonalNumber pn)
        {
            _ = pn ?? throw new ArgumentNullException(nameof(pn));

            return $"{pn.DateOfBirth:yyMMdd}{pn.OrdinalNumber:0000}";
        }
    }

    /// <summary>
    /// Formats a Swedish personal number using the formatter yyyyMMdd-xxxx.
    /// </summary>
    public class TwelveDigitsSwedishPersonalNumberFormatter : SwedishPersonalNumberFormatter
    {
        /// <inheritdoc/>
        public override string Format(SwedishPersonalNumber pn)
        {
            _ = pn ?? throw new ArgumentNullException(nameof(pn));

            return $"{pn.DateOfBirth:yyyyMMdd}-{pn.OrdinalNumber:0000}";
        }
    }

    /// <summary>
    /// Formats a Swedish personal number using the formatter yyMMdd-xxxx.
    /// </summary>
    public class TenDigitsSwedishPersonalNumberFormatter : SwedishPersonalNumberFormatter
    {
        /// <inheritdoc/>
        public override string Format(SwedishPersonalNumber pn)
        {
            _ = pn ?? throw new ArgumentNullException(nameof(pn));

            return $"{pn.DateOfBirth:yyMMdd}-{pn.OrdinalNumber:0000}";
        }
    }

    /// <summary>
    /// Formats a Swedish personal number using the formatter yyyyMMdd-xxxx.
    /// </summary>
    public class SplitTwelveDigitsSwedishPersonalNumberFormatter : SwedishPersonalNumberFormatter
    {
        /// <inheritdoc/>
        public override string Format(SwedishPersonalNumber pn)
        {
            _ = pn ?? throw new ArgumentNullException(nameof(pn));

            return $"{pn.DateOfBirth:yyyy-MM-dd}-{pn.OrdinalNumber:0000}";
        }
    }

    /// <summary>
    /// Formats a Swedish personal number using the formatter yyMMdd-xxxx.
    /// </summary>
    public class SplitTenDigitsSwedishPersonalNumberFormatter : SwedishPersonalNumberFormatter
    {
        /// <inheritdoc/>
        public override string Format(SwedishPersonalNumber pn)
        {
            _ = pn ?? throw new ArgumentNullException(nameof(pn));

            return $"{pn.DateOfBirth:yy-MM-dd}-{pn.OrdinalNumber:0000}";
        }
    }
}
