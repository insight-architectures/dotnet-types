namespace InsightArchitectures.Types
{
    /// <summary>
    /// A set of formats that can be used to represent a Swedish Personal Identity Number.
    /// </summary>
    public static class SwedishPersonalIdentityNumberFormats
    {
        /// <summary>
        /// A formatter that formats a <see cref="SwedishPersonalIdentityNumber" /> using the formatter <c>yyyyMMdd-xxxx</c>.
        /// </summary>
        public static readonly SwedishPersonalIdentityNumberFormatter TwelveDigits = new TwelveDigitsSwedishPersonalIdentityNumberFormatter();

        /// <summary>
        /// A formatter that formats a <see cref="SwedishPersonalIdentityNumber" /> using the formatter <c>yyMMdd-xxxx</c>.
        /// </summary>
        public static readonly SwedishPersonalIdentityNumberFormatter TenDigits = new TenDigitsSwedishPersonalIdentityNumberFormatter();

        /// <summary>
        /// A formatter that formats a <see cref="SwedishPersonalIdentityNumber" /> using the formatter <c>yyyyMMddxxxx</c>.
        /// </summary>
        public static readonly SwedishPersonalIdentityNumberFormatter NoSplitTwelveDigits = new NoSplitTwelveDigitsSwedishPersonalIdentityNumberFormatter();

        /// <summary>
        /// A formatter that formats a <see cref="SwedishPersonalIdentityNumber" /> using the formatter <c>yyMMddxxxx</c>.
        /// </summary>
        public static readonly SwedishPersonalIdentityNumberFormatter NoSplitTenDigits = new NoSplitTenDigitsSwedishPersonalIdentityNumberFormatter();

        /// <summary>
        /// A formatter that formats a <see cref="SwedishPersonalIdentityNumber" /> using the formatter <c>yyyy-MM-dd-xxxx</c>.
        /// </summary>
        public static readonly SwedishPersonalIdentityNumberFormatter SplitTwelveDigits = new SplitTwelveDigitsSwedishPersonalIdentityNumberFormatter();

        /// <summary>
        /// A formatter that formats a <see cref="SwedishPersonalIdentityNumber" /> using the formatter <c>yy-MM-dd-xxxx</c>.
        /// </summary>
        public static readonly SwedishPersonalIdentityNumberFormatter SplitTenDigits = new SplitTenDigitsSwedishPersonalIdentityNumberFormatter();
    }
}
