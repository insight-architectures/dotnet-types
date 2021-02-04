using System;
using AutoFixture.Idioms;
using InsightArchitectures.Types;
using Moq;
using NUnit.Framework;
using RangeAttribute = System.ComponentModel.DataAnnotations.RangeAttribute;

namespace Tests
{
    [TestFixture]
    [TestOf(typeof(SwedishPersonalIdentityNumber))]
    public class SwedishPersonalIdentityNumberTests
    {
        [Test, CustomAutoData]
        public void Constructor_throws_if_ordinal_is_less_than_zero(DateTime date, [Range(-10_000, -1)] int ordinal)
        {
            Assert.That(() => new SwedishPersonalIdentityNumber(date, ordinal), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test, CustomAutoData]
        public void Constructor_throws_if_ordinal_is_bigger_than_9_999(DateTime date, [Range(10_000, 100_000)] int ordinal)
        {
            Assert.That(() => new SwedishPersonalIdentityNumber(date, ordinal), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test, CustomAutoData]
        public void Constructor_sets_properties(ConstructorInitializedMemberAssertion assertion) => assertion.Verify(typeof(SwedishPersonalIdentityNumber));

        [Test, CustomAutoData]
        public void ToFormattedString_uses_formatter(SwedishPersonalIdentityNumber sut, SwedishPersonalIdentityNumberFormatter formatter, string result)
        {
            Mock.Get(formatter).Setup(p => p.Format(It.IsAny<SwedishPersonalIdentityNumber>())).Returns(result);

            var actual = sut.ToFormattedString(formatter);

            Assert.That(actual, Is.EqualTo(result));
        }

        [Test, CustomAutoData]
        public void ToString_returns_twelve_digits_format(SwedishPersonalIdentityNumber sut)
        {
            var expected = sut.ToFormattedString(SwedishPersonalIdentityNumberFormats.TwelveDigits);
            
            var actual = sut.ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
