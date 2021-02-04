using System;
using System.Collections;
using System.Collections.Generic;
using AutoFixture;
using InsightArchitectures.Types;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    [TestOf(typeof(SwedishPersonalIdentityNumberFormatter))]
    public class SwedishPersonalIdentityNumberFormatterTests
    {
        [Test, TestCaseSource(nameof(GetTestCases))]
        public void Format_uses_expected_format(SwedishPersonalIdentityNumberFormatter sut, SwedishPersonalIdentityNumber pin, string format)
        {
            var result = sut.Format(pin);

            Assert.That(result, Does.Match(format));
        }
        
        public static IEnumerable<object[]> GetTestCases()
        {
            var fixture = new Fixture();

            yield return new object []{ new NoSplitTenDigitsSwedishPersonalIdentityNumberFormatter(), fixture.Create<SwedishPersonalIdentityNumber>(), @"^\d{10}$"};

            yield return new object[] { new SplitTenDigitsSwedishPersonalIdentityNumberFormatter(), fixture.Create<SwedishPersonalIdentityNumber>(), @"^\d{2}-\d{2}-\d{2}-\d{4}$" };

            yield return new object[] { new TenDigitsSwedishPersonalIdentityNumberFormatter(), fixture.Create<SwedishPersonalIdentityNumber>(), @"^\d{6}-\d{4}$" };

            yield return new object[] { new NoSplitTwelveDigitsSwedishPersonalIdentityNumberFormatter(), fixture.Create<SwedishPersonalIdentityNumber>(), @"^\d{12}$" };

            yield return new object[] { new SplitTwelveDigitsSwedishPersonalIdentityNumberFormatter(), fixture.Create<SwedishPersonalIdentityNumber>(), @"^\d{4}-\d{2}-\d{2}-\d{4}$" };

            yield return new object[] { new TwelveDigitsSwedishPersonalIdentityNumberFormatter(), fixture.Create<SwedishPersonalIdentityNumber>(), @"^\d{8}-\d{4}$" };
        }
    }
}
