using System;
using AutoFixture.Idioms;
using InsightArchitectures.Types;
using Moq;
using NUnit.Framework;
using RangeAttribute = System.ComponentModel.DataAnnotations.RangeAttribute;

namespace Tests
{
    [TestFixture]
    [TestOf(typeof(SwedishPersonalNumber))]
    public class SwedishPersonalNumberTests
    {
        [Test, CustomAutoData]
        public void Constructor_throws_if_ordinal_is_less_than_zero(DateTime date, [Range(-10_000, -1)] int ordinal)
        {
            Assert.That(() => new SwedishPersonalNumber(date, ordinal), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test, CustomAutoData]
        public void Constructor_throws_if_ordinal_is_bigger_than_9_999(DateTime date, [Range(10_000, 100_000)] int ordinal)
        {
            Assert.That(() => new SwedishPersonalNumber(date, ordinal), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test, CustomAutoData]
        public void Constructor_sets_properties(ConstructorInitializedMemberAssertion assertion) => assertion.Verify(typeof(SwedishPersonalNumber));

        [Test, CustomAutoData]
        public void ToFormattedString_uses_formatter(SwedishPersonalNumber sut, SwedishPersonalNumberFormatter formatter, string result)
        {
            Mock.Get(formatter).Setup(p => p.Format(It.IsAny<SwedishPersonalNumber>())).Returns(result);

            var actual = sut.ToFormattedString(formatter);

            Assert.That(actual, Is.EqualTo(result));
        }

        [Test, CustomAutoData]
        public void ToString_returns_twelve_digits_format(SwedishPersonalNumber sut)
        {
            var expected = sut.ToFormattedString(SwedishPersonalNumberFormatter.TwelveDigits);
            
            var actual = sut.ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    [TestFixture]
    [TestOf(typeof(SwedishPersonalNumber))]
    public class SwedishPersonalNumberParsingTests
    {
        [Test, CustomAutoData]
        public void Random_string_returns_false(string input)
        {
            var isSuccess = SwedishPersonalNumber.TryParse(input, out var result);
            
            Assert.Multiple(() =>
            {
                Assert.That(isSuccess, Is.False);
                Assert.That(result, Is.Null);
            });
        }
        
        [Test, CustomAutoData]
        public void Twelve_digits_format_is_parsed(DateTime date, [Range(1, 9999)] int ordinal)
        {
            var input = $"{date:yyyyMMdd}-{ordinal:0000}";

            var isSuccess = SwedishPersonalNumber.TryParse(input, out var result);
            
            Assert.Multiple(() =>
            {
                Assert.That(isSuccess, Is.True);
                Assert.That(result, Is.Not.Null);
                Assert.That(result.DateOfBirth, Is.EqualTo(date.Date));
                Assert.That(result.OrdinalNumber, Is.EqualTo(ordinal));
            });
        }

        [Test, CustomAutoData]
        public void Ten_digits_format_is_parsed(DateTime date, [Range(1900, 1999)] int year, [Range(1, 9999)] int ordinal)
        {
            date = new DateTime(year, date.Month, date.Day);
            
            var input = $"{date:yyMMdd}-{ordinal:0000}";

            var isSuccess = SwedishPersonalNumber.TryParse(input, out var result);

            Assert.Multiple(() =>
            {
                Assert.That(isSuccess, Is.True);
                Assert.That(result, Is.Not.Null);
                Assert.That(result.DateOfBirth, Is.EqualTo(date.Date));
                Assert.That(result.OrdinalNumber, Is.EqualTo(ordinal));
            });
        }

        [Test, CustomAutoData]
        public void Twelve_digits_no_split_format_is_parsed(DateTime date, [Range(1, 9999)] int ordinal)
        {
            var input = $"{date:yyyyMMdd}{ordinal:0000}";

            var isSuccess = SwedishPersonalNumber.TryParse(input, out var result);

            Assert.Multiple(() =>
            {
                Assert.That(isSuccess, Is.True);
                Assert.That(result, Is.Not.Null);
                Assert.That(result.DateOfBirth, Is.EqualTo(date.Date));
                Assert.That(result.OrdinalNumber, Is.EqualTo(ordinal));
            });
        }

        [Test, CustomAutoData]
        public void Ten_digits_format_no_split_is_parsed(DateTime date, [Range(1900, 1999)] int year, [Range(1, 9999)] int ordinal)
        {
            date = new DateTime(year, date.Month, date.Day);

            var input = $"{date:yyMMdd}{ordinal:0000}";

            var isSuccess = SwedishPersonalNumber.TryParse(input, out var result);

            Assert.Multiple(() =>
            {
                Assert.That(isSuccess, Is.True);
                Assert.That(result, Is.Not.Null);
                Assert.That(result.DateOfBirth, Is.EqualTo(date.Date));
                Assert.That(result.OrdinalNumber, Is.EqualTo(ordinal));
            });
        }

        [Test, CustomAutoData]
        public void Twelve_digits_split_format_is_parsed(DateTime date, [Range(1, 9999)] int ordinal)
        {
            var input = $"{date:yyyy-MM-dd}-{ordinal:0000}";

            var isSuccess = SwedishPersonalNumber.TryParse(input, out var result);

            Assert.Multiple(() =>
            {
                Assert.That(isSuccess, Is.True);
                Assert.That(result, Is.Not.Null);
                Assert.That(result.DateOfBirth, Is.EqualTo(date.Date));
                Assert.That(result.OrdinalNumber, Is.EqualTo(ordinal));
            });
        }

        [Test, CustomAutoData]
        public void Ten_digits_format_split_is_parsed(DateTime date, [Range(1900, 1999)] int year, [Range(1, 9999)] int ordinal)
        {
            date = new DateTime(year, date.Month, date.Day);

            var input = $"{date:yy-MM-dd}-{ordinal:0000}";

            var isSuccess = SwedishPersonalNumber.TryParse(input, out var result);

            Assert.Multiple(() =>
            {
                Assert.That(isSuccess, Is.True);
                Assert.That(result, Is.Not.Null);
                Assert.That(result.DateOfBirth, Is.EqualTo(date.Date));
                Assert.That(result.OrdinalNumber, Is.EqualTo(ordinal));
            });
        }
    }
}
