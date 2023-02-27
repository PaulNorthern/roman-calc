using System.Text;

namespace RomanLibrary;

public class ArabicToRomanConverter 
{
    private List<Tuple<string, int>> symList = new()
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
    /// Converting an Arabic number to a Roman number. 
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public string Convert(int num)
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
}