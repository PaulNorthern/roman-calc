namespace RomanLibrary;

public class RomanToArabicConverter
{
    private Dictionary<char, int> _roman = new()
    {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000},
    };
    
    public int Convert(string s)
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