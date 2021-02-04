using System;

namespace InsightArchitectures.Types
{
    /// <summary>
    /// An abstract class that represents the different ways to formatter a Swedish personal identity number as a string.
    /// </summary>
    public abstract class SwedishPersonalIdentityNumberFormatter
    {
        /// <summary>
        /// Formats the <paramref name="pin"/> according to the specified concrete implementation.
        /// </summary>
        /// <param name="pin">The Swedish personal identity number to formatter as string.</param>
        /// <returns>The string formatted according to the concrete implementation.</returns>
        public abstract string Format(SwedishPersonalIdentityNumber pin);
    }

    /// <summary>
    /// Formats a Swedish personal identity number using the formatter yyyyMMddxxxx.
    /// </summary>
    public class NoSplitTwelveDigitsSwedishPersonalIdentityNumberFormatter : SwedishPersonalIdentityNumberFormatter
    {
        /// <inheritdoc/>
        public override string Format(SwedishPersonalIdentityNumber pn)
        {
            _ = pn ?? throw new ArgumentNullException(nameof(pn));

            return $"{pn.DateOfBirth:yyyyMMdd}{pn.OrdinalNumber:0000}";
        }
    }

    /// <summary>
    /// Formats a Swedish personal identity number using the formatter yyMMddxxxx.
    /// </summary>
    public class NoSplitTenDigitsSwedishPersonalIdentityNumberFormatter : SwedishPersonalIdentityNumberFormatter
    {
        /// <inheritdoc/>
        public override string Format(SwedishPersonalIdentityNumber pn)
        {
            _ = pn ?? throw new ArgumentNullException(nameof(pn));

            return $"{pn.DateOfBirth:yyMMdd}{pn.OrdinalNumber:0000}";
        }
    }

    /// <summary>
    /// Formats a Swedish personal identity number using the formatter yyyyMMdd-xxxx.
    /// </summary>
    public class TwelveDigitsSwedishPersonalIdentityNumberFormatter : SwedishPersonalIdentityNumberFormatter
    {
        /// <inheritdoc/>
        public override string Format(SwedishPersonalIdentityNumber pn)
        {
            _ = pn ?? throw new ArgumentNullException(nameof(pn));

            return $"{pn.DateOfBirth:yyyyMMdd}-{pn.OrdinalNumber:0000}";
        }
    }

    /// <summary>
    /// Formats a Swedish personal identity number using the formatter yyMMdd-xxxx.
    /// </summary>
    public class TenDigitsSwedishPersonalIdentityNumberFormatter : SwedishPersonalIdentityNumberFormatter
    {
        /// <inheritdoc/>
        public override string Format(SwedishPersonalIdentityNumber pn)
        {
            _ = pn ?? throw new ArgumentNullException(nameof(pn));

            return $"{pn.DateOfBirth:yyMMdd}-{pn.OrdinalNumber:0000}";
        }
    }

    /// <summary>
    /// Formats a Swedish personal identity number using the formatter yyyyMMdd-xxxx.
    /// </summary>
    public class SplitTwelveDigitsSwedishPersonalIdentityNumberFormatter : SwedishPersonalIdentityNumberFormatter
    {
        /// <inheritdoc/>
        public override string Format(SwedishPersonalIdentityNumber pn)
        {
            _ = pn ?? throw new ArgumentNullException(nameof(pn));

            return $"{pn.DateOfBirth:yyyy-MM-dd}-{pn.OrdinalNumber:0000}";
        }
    }

    /// <summary>
    /// Formats a Swedish personal identity number using the formatter yyMMdd-xxxx.
    /// </summary>
    public class SplitTenDigitsSwedishPersonalIdentityNumberFormatter : SwedishPersonalIdentityNumberFormatter
    {
        /// <inheritdoc/>
        public override string Format(SwedishPersonalIdentityNumber pn)
        {
            _ = pn ?? throw new ArgumentNullException(nameof(pn));

            return $"{pn.DateOfBirth:yy-MM-dd}-{pn.OrdinalNumber:0000}";
        }
    }
}
