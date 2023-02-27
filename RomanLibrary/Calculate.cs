using System.Text;

namespace RomanLibrary;
using org.matheval;

/// <summary>
/// Calculation of Roman expressions.
/// </summary>
public class Calculate
{
    private static Dictionary<char, int> _roman = new()
    {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000},
    };
    
    /// <summary>
    /// Calculates a mathematical expression from Roman numbers to Arabic.
    /// </summary>
    /// <param name="input">(IV + CM) / II")</param>
    /// <returns>Arabic number: 452</returns>
    public int Evaluate(string input)
    {
        Expression expression = new Expression(input);
        List<String> errors = expression.GetError();
        
        if (errors.Count == 0)
        {
            // get variables
            List<String> variables = expression.getVariables();
            foreach (String variable in variables)
            {
                expression.Bind(variable, ConvertRomanIntoArabic(variable));
            }
        }
        
        return Convert.ToInt32(expression.Eval());
    }
    
    /// <summary>
    /// Converting a Roman number to an Arabic one.
    /// </summary>
    /// <param name="s">IV</param>
    /// <returns>4</returns>
    private static int ConvertRomanIntoArabic(string s)
    {
        int res = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (i + 1 < s.Length && _roman[s[i]] < _roman[s[i + 1]])
            {
                res -= _roman[s[i]];
            } 
            else
            {
                res += _roman[s[i]];
            }
        }

        return res;
    }
}