using RomanLibrary;
using Xunit;

namespace Test;

public class RomanMathTest
{
    [Theory]
    [InlineData("(IV + CM) / II", 452)]
    [InlineData("(MMMDCCXXIV - MMCCXXIX) * II", 2990)]
    [InlineData("(IX - V) + MXX", 1024)]
    public void calculate_roman_to_arabic(string input, int expected)
    {
        // Arrange
        var calculate = new Calculate();

        // Act
        var result = calculate.Evaluate(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(2048, "MMXLVIII")]
    public void convert_arabic_to_roman(int input, string expected)
    {
        // Arrange
        var calculate = new Calculate();

        // Act
        var result = calculate.ConvertArabicIntoRoman(input);

        // Assert
        Assert.Equal(expected, result);
    }
}