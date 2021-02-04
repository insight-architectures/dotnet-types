using System;
using InsightArchitectures.Types;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    [TestOf(typeof(SwedishPersonalIdentityNumber))]
    public class SwedishPersonalIdentityNumberParsingTests
    {
        [Test, CustomAutoData]
        public void TryParse_returns_false_from_Random_string(string input)
        {
            var isSuccess = SwedishPersonalIdentityNumber.TryParse(input, out var result);
            
            Assert.Multiple(() =>
            {
                Assert.That(isSuccess, Is.False);
                Assert.That(result, Is.Null);
            });
        }
        
        [Test, CustomAutoData]
        public void TryParse_can_parse_Twelve_digits_format(DateTime date, [System.ComponentModel.DataAnnotations.Range(1, 9999)] int ordinal)
        {
            var input = $"{date:yyyyMMdd}-{ordinal:0000}";

            var isSuccess = SwedishPersonalIdentityNumber.TryParse(input, out var result);
            
            Assert.Multiple(() =>
            {
                Assert.That(isSuccess, Is.True);
                Assert.That(result, Is.Not.Null);
                Assert.That(result.DateOfBirth, Is.EqualTo(date.Date));
                Assert.That(result.OrdinalNumber, Is.EqualTo(ordinal));
            });
        }

        [Test, CustomAutoData]
        public void TryParse_can_parse_Ten_digits_format(DateTime date, [System.ComponentModel.DataAnnotations.Range(1900, 1999)] int year, [System.ComponentModel.DataAnnotations.Range(1, 9999)] int ordinal)
        {
            date = new DateTime(year, date.Month, date.Day);
            
            var input = $"{date:yyMMdd}-{ordinal:0000}";

            var isSuccess = SwedishPersonalIdentityNumber.TryParse(input, out var result);

            Assert.Multiple(() =>
            {
                Assert.That(isSuccess, Is.True);
                Assert.That(result, Is.Not.Null);
                Assert.That(result.DateOfBirth, Is.EqualTo(date.Date));
                Assert.That(result.OrdinalNumber, Is.EqualTo(ordinal));
            });
        }

        [Test, CustomAutoData]
        public void TryParse_can_parse_Twelve_digits_no_split_format(DateTime date, [System.ComponentModel.DataAnnotations.Range(1, 9999)] int ordinal)
        {
            var input = $"{date:yyyyMMdd}{ordinal:0000}";

            var isSuccess = SwedishPersonalIdentityNumber.TryParse(input, out var result);

            Assert.Multiple(() =>
            {
                Assert.That(isSuccess, Is.True);
                Assert.That(result, Is.Not.Null);
                Assert.That(result.DateOfBirth, Is.EqualTo(date.Date));
                Assert.That(result.OrdinalNumber, Is.EqualTo(ordinal));
            });
        }

        [Test, CustomAutoData]
        public void TryParse_can_parse_Ten_digits_format_no_split(DateTime date, [System.ComponentModel.DataAnnotations.Range(1900, 1999)] int year, [System.ComponentModel.DataAnnotations.Range(1, 9999)] int ordinal)
        {
            date = new DateTime(year, date.Month, date.Day);

            var input = $"{date:yyMMdd}{ordinal:0000}";

            var isSuccess = SwedishPersonalIdentityNumber.TryParse(input, out var result);

            Assert.Multiple(() =>
            {
                Assert.That(isSuccess, Is.True);
                Assert.That(result, Is.Not.Null);
                Assert.That(result.DateOfBirth, Is.EqualTo(date.Date));
                Assert.That(result.OrdinalNumber, Is.EqualTo(ordinal));
            });
        }

        [Test, CustomAutoData]
        public void TryParse_can_parse_Twelve_digits_split_format(DateTime date, [System.ComponentModel.DataAnnotations.Range(1, 9999)] int ordinal)
        {
            var input = $"{date:yyyy-MM-dd}-{ordinal:0000}";

            var isSuccess = SwedishPersonalIdentityNumber.TryParse(input, out var result);

            Assert.Multiple(() =>
            {
                Assert.That(isSuccess, Is.True);
                Assert.That(result, Is.Not.Null);
                Assert.That(result.DateOfBirth, Is.EqualTo(date.Date));
                Assert.That(result.OrdinalNumber, Is.EqualTo(ordinal));
            });
        }

        [Test, CustomAutoData]
        public void TryParse_can_parse_Ten_digits_split_format(DateTime date, [System.ComponentModel.DataAnnotations.Range(1900, 1999)] int year, [System.ComponentModel.DataAnnotations.Range(1, 9999)] int ordinal)
        {
            date = new DateTime(year, date.Month, date.Day);

            var input = $"{date:yy-MM-dd}-{ordinal:0000}";

            var isSuccess = SwedishPersonalIdentityNumber.TryParse(input, out var result);

            Assert.Multiple(() =>
            {
                Assert.That(isSuccess, Is.True);
                Assert.That(result, Is.Not.Null);
                Assert.That(result.DateOfBirth, Is.EqualTo(date.Date));
                Assert.That(result.OrdinalNumber, Is.EqualTo(ordinal));
            });
        }

        [Test]
        [Property("Issue", 3)]
        [Property("IssueLink", "https://github.com/insight-architectures/dotnet-types/issues/3")]
        [CustomInlineAutoData("1234567890")]
        [CustomInlineAutoData("12345678-9012")]
        [CustomInlineAutoData("12345678")]
        [CustomInlineAutoData("123456-7890")]
        [CustomInlineAutoData("12-34-56-7890")]
        [CustomInlineAutoData("1234-56-78-9012")]
        public void TryParse_should_not_throw_when_input_date_is_not_valid(string input)
        {
            var result = SwedishPersonalIdentityNumber.TryParse(input, out _);

            Assert.That(result, Is.False);
        }

        [Test, CustomAutoData]
        public void Parse_throws_from_Random_string(string input)
        {
            Assume.That(SwedishPersonalIdentityNumber.TryParse(input, out _), Is.False);

            Assert.That(() => SwedishPersonalIdentityNumber.Parse(input), Throws.TypeOf<FormatException>());
        }

        [Test, CustomAutoData]
        public void Parse_can_parse_Twelve_digits_format(DateTime date, [System.ComponentModel.DataAnnotations.Range(1, 9999)] int ordinal)
        {
            var input = $"{date:yyyyMMdd}-{ordinal:0000}";

            var result = SwedishPersonalIdentityNumber.Parse(input);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.DateOfBirth, Is.EqualTo(date.Date));
                Assert.That(result.OrdinalNumber, Is.EqualTo(ordinal));
            });
        }

        [Test, CustomAutoData]
        public void Parse_can_parse_Ten_digits_format(DateTime date, [System.ComponentModel.DataAnnotations.Range(1900, 1999)] int year, [System.ComponentModel.DataAnnotations.Range(1, 9999)] int ordinal)
        {
            date = new DateTime(year, date.Month, date.Day);

            var input = $"{date:yyMMdd}-{ordinal:0000}";

            var result = SwedishPersonalIdentityNumber.Parse(input);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.DateOfBirth, Is.EqualTo(date.Date));
                Assert.That(result.OrdinalNumber, Is.EqualTo(ordinal));
            });
        }

        [Test, CustomAutoData]
        public void Parse_can_parse_Twelve_digits_no_split_format(DateTime date, [System.ComponentModel.DataAnnotations.Range(1, 9999)] int ordinal)
        {
            var input = $"{date:yyyyMMdd}{ordinal:0000}";

            var result = SwedishPersonalIdentityNumber.Parse(input);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.DateOfBirth, Is.EqualTo(date.Date));
                Assert.That(result.OrdinalNumber, Is.EqualTo(ordinal));
            });
        }

        [Test, CustomAutoData]
        public void Parse_can_parse_Ten_digits_format_no_split(DateTime date, [System.ComponentModel.DataAnnotations.Range(1900, 1999)] int year, [System.ComponentModel.DataAnnotations.Range(1, 9999)] int ordinal)
        {
            date = new DateTime(year, date.Month, date.Day);

            var input = $"{date:yyMMdd}{ordinal:0000}";

            var result = SwedishPersonalIdentityNumber.Parse(input);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.DateOfBirth, Is.EqualTo(date.Date));
                Assert.That(result.OrdinalNumber, Is.EqualTo(ordinal));
            });
        }

        [Test, CustomAutoData]
        public void Parse_can_parse_Twelve_digits_split_format(DateTime date, [System.ComponentModel.DataAnnotations.Range(1, 9999)] int ordinal)
        {
            var input = $"{date:yyyy-MM-dd}-{ordinal:0000}";

            var result = SwedishPersonalIdentityNumber.Parse(input);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.DateOfBirth, Is.EqualTo(date.Date));
                Assert.That(result.OrdinalNumber, Is.EqualTo(ordinal));
            });
        }

        [Test, CustomAutoData]
        public void Parse_can_parse_Ten_digits_split_format(DateTime date, [System.ComponentModel.DataAnnotations.Range(1900, 1999)] int year, [System.ComponentModel.DataAnnotations.Range(1, 9999)] int ordinal)
        {
            date = new DateTime(year, date.Month, date.Day);

            var input = $"{date:yy-MM-dd}-{ordinal:0000}";

            var result = SwedishPersonalIdentityNumber.Parse(input);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.DateOfBirth, Is.EqualTo(date.Date));
                Assert.That(result.OrdinalNumber, Is.EqualTo(ordinal));
            });
        }

        [Test]
        [Property("Issue", 3)]
        [Property("IssueLink", "https://github.com/insight-architectures/dotnet-types/issues/3")]
        [CustomInlineAutoData("1234567890")]
        [CustomInlineAutoData("12345678-9012")]
        [CustomInlineAutoData("12345678")]
        [CustomInlineAutoData("123456-7890")]
        [CustomInlineAutoData("12-34-56-7890")]
        [CustomInlineAutoData("1234-56-78-9012")]
        public void Parse_should_throw_when_input_date_is_not_valid(string input)
        {
            Assume.That(SwedishPersonalIdentityNumber.TryParse(input, out _), Is.False);
            
            Assert.That(() => SwedishPersonalIdentityNumber.Parse(input), Throws.TypeOf<FormatException>());
        }
    }
}
