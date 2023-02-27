using org.matheval;

namespace RomanLibrary;

public static class MathExpression
{
    /// <summary>
    /// Calculates the expression in Arabic numerals.
    /// </summary>
    /// <param name="input">Roman expression</param>
    /// <returns></returns>
    public static int CalculateExpression(string input)
    {
        Expression expression = new Expression(input);
        List<String> errors = expression.GetError();
        
        if (errors.Count == 0)
        {
            // get variables
            List<String> variables = expression.getVariables();
            foreach (String variable in variables)
            {
                expression.Bind(variable, new RomanToArabicConverter().Convert(variable));
            }
        }

        return Convert.ToInt32(expression.Eval());
    }
}