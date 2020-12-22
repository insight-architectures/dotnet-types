using System;
using System.Collections;
using System.Collections.Generic;
using AutoFixture;
using InsightArchitectures.Types;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    [TestOf(typeof(SwedishPersonalNumberFormatter))]
    public class SwedishPersonalNumberFormatterTests
    {
        [Test, TestCaseSource(nameof(GetTestCases))]
        public void Format_uses_expected_format(SwedishPersonalNumberFormatter sut, SwedishPersonalNumber personalNumber, string format)
        {
            var result = sut.Format(personalNumber);

            Assert.That(result, Does.Match(format));
        }
        
        public static IEnumerable<object[]> GetTestCases()
        {
            var fixture = new Fixture();

            yield return new object []{ new NoSplitTenDigitsSwedishPersonalNumberFormatter(), fixture.Create<SwedishPersonalNumber>(), @"^\d{10}$"};

            yield return new object[] { new SplitTenDigitsSwedishPersonalNumberFormatter(), fixture.Create<SwedishPersonalNumber>(), @"^\d{2}-\d{2}-\d{2}-\d{4}$" };

            yield return new object[] { new TenDigitsSwedishPersonalNumberFormatter(), fixture.Create<SwedishPersonalNumber>(), @"^\d{6}-\d{4}$" };

            yield return new object[] { new NoSplitTwelveDigitsSwedishPersonalNumberFormatter(), fixture.Create<SwedishPersonalNumber>(), @"^\d{12}$" };

            yield return new object[] { new SplitTwelveDigitsSwedishPersonalNumberFormatter(), fixture.Create<SwedishPersonalNumber>(), @"^\d{4}-\d{2}-\d{2}-\d{4}$" };

            yield return new object[] { new TwelveDigitsSwedishPersonalNumberFormatter(), fixture.Create<SwedishPersonalNumber>(), @"^\d{8}-\d{4}$" };
        }
    }
}
