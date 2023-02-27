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
    
    private static List<Tuple<string, int>> symList = new()
    {
        new Tuple<string, int>("I", 1),
        new Tuple<string, int>("IV", 4),
        new Tuple<string, int>("V", 5),
        new Tuple<string, int>("IX", 9),
        new Tuple<string, int>("X", 10),
        new Tuple<string, int>("XL", 40),
        new Tuple<string, int>("L", 50),
        new Tuple<string, int>("XC", 90),
        new Tuple<string, int>("C", 100),
        new Tuple<string, int>("CD", 400),
        new Tuple<string, int>("D", 500),
        new Tuple<string, int>("CM", 900),
        new Tuple<string, int>("M", 1000),
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

    public string ConvertArabicIntoRoman(int num)
    {
        var result = new StringBuilder("");
        symList.Reverse();
       
        foreach (var (sym, val) in symList)
        {
            if (num / val != 0)
            {
                int count = num / val;
                if (count > 1)
                {
                    result.Append(sym.ToCharArray()[0], count);
                }
                else
                {
                    result.Append(sym);
                }
                
                num %= val;
            }
            
        }
        
        return result.ToString();
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