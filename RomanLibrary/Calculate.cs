namespace RomanLibrary;

/// <summary>
/// Calculation of Roman expressions.
/// </summary>
public class Calculate
{
    /// <summary>
    /// Calculates a mathematical Roman expression.
    /// </summary>
    /// <param name="input">"(MMMDCCXXIV - MMCCXXIX) * II"</param>
    /// <returns>MMCMXC</returns>
    public string Evaluate(string input)
    {
        var number = MathExpression.CalculateExpression(input);
        var arabicToRoman = new ArabicToRomanConverter();
        return arabicToRoman.Convert(number);
    }
}