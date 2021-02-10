using System.Collections.Generic;
using AutoFixture;
using InsightArchitectures.Types;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Issues
    {
        [Test]
        [Property("Issue", 7)]
        [Property("IssueLink", "https://github.com/insight-architectures/dotnet-types/issues/7")]
        [TestCaseSource(nameof(GetFormatterAndTestSubject))]
        public void Roundtrip_should_be_supported(SwedishPersonalIdentityNumberFormatter formatter, SwedishPersonalIdentityNumber input)
        {
            var formatted = input.ToFormattedString(formatter);

            var parsed = SwedishPersonalIdentityNumber.Parse(formatted);

            Assert.That(parsed, Is.EqualTo(input));
        }

        public static IEnumerable<object> GetFormatterAndTestSubject()
        {
            var fixture = new Fixture();

            yield return new object[] { SwedishPersonalIdentityNumberFormats.NoSplitTwelveDigits, fixture.Create<SwedishPersonalIdentityNumber>() };

            yield return new object[] { SwedishPersonalIdentityNumberFormats.SplitTwelveDigits, fixture.Create<SwedishPersonalIdentityNumber>() };

            yield return new object[] { SwedishPersonalIdentityNumberFormats.TwelveDigits, fixture.Create<SwedishPersonalIdentityNumber>() };
        }
    }
}
