using System.Text;

using FirstConsoleApp.TowerOfHanoi.Helpers;

using Xunit;

namespace TowerOfHanoi.Tests
{
    public class ImportFromUserValidatorTests
    {
        public class InputFromUserValidatorTests
        {
            [Theory]
            [InlineData("1")]
            [InlineData("2")]
            [InlineData("10")]
            [InlineData("999")]
            public void IsNimberOfDisksValid_WhenPositiveInteger_ReturnsTrue(string input)
            {
                Assert.True(InputFromUserValidator.IsNimberOfDisksValid(input));
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData(" ")]
            [InlineData("0")]
            [InlineData("-1")]
            [InlineData("abc")]
            [InlineData("1.5")]
            public void IsNimberOfDisksValid_WhenInvalid_ReturnsFalse(string? input)
            {
                Assert.False(InputFromUserValidator.IsNimberOfDisksValid(input));
            }

            [Theory]
            [InlineData("1")]
            [InlineData("2")]
            [InlineData("3")]
            public void IsActionWithRodsValid_WhenWithinRange_ReturnsTrue_AndPrintsNothing(string input)
            {
                var (result, output) = CaptureConsoleOut(() => InputFromUserValidator.IsActionWithRodsValid(input));

                Assert.True(result);
                Assert.True(string.IsNullOrEmpty(output));
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData(" ")]
            [InlineData("0")]
            [InlineData("-1")]
            [InlineData("4")]
            [InlineData("abc")]
            public void IsActionWithRodsValid_WhenInvalid_ReturnsFalse_AndPrintsInvalidOperation(string? input)
            {
                var (result, output) = CaptureConsoleOut(() => InputFromUserValidator.IsActionWithRodsValid(input!));

                Assert.False(result);
                Assert.Contains("Invalid operation", output);
            }

            private static (bool Result, string Output) CaptureConsoleOut(Func<bool> action)
            {
                var originalOut = Console.Out;
                try
                {
                    using var sw = new StringWriter(new StringBuilder());
                    Console.SetOut(sw);
                    var result = action();
                    sw.Flush();
                    return (result, sw.ToString());
                }
                finally
                {
                    Console.SetOut(originalOut);
                }
            }
        }
    }
}