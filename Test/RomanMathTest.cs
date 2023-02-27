using RomanLibrary;
using Xunit;

namespace Test;

public class RomanMathTest
{
    [Theory]
    [InlineData("IV", 4)]
    [InlineData("CX", 110)]
    [InlineData("MMXXIII", 2023)]
    public void calculate_roman_to_arabic(string input, int expected)
    {
        // Arrange
        var converter = new RomanToArabicConverter();

        // Act
        var result = converter.Convert(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(2048, "MMXLVIII")]
    public void convert_arabic_to_roman(int input, string expected)
    {
        // Arrange
        var converter = new ArabicToRomanConverter();

        // Act
        var result = converter.Convert(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("(MMMDCCXXIV - MMCCXXIX) * II", "MMCMXC")]
    public void return_correct_result(string input, string expected)
    {
        // Arrange
        var calc = new Calculate();
        
        // Act
        var result = calc.Evaluate(input);

        // Assert
        Assert.Equal(expected, result);
    }
}