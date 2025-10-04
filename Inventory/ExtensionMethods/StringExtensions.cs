using System.Text;

namespace Inventory.ExtensionMethods;

public static class StringExtensions
{
    public static bool IsPalindrome(this string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return true;

        var str = s.CleanUpString();

        int left = 0, right = str.Length - 1;
        while (left < right)
        {
            if (str[left] != str[right])
                return false;
            left++;
            right--;
        }
        return true;
    }

    private static string CleanUpString(this string input)
    {
        var resultBuilder = new StringBuilder();
        foreach (var c in input)
        {
            if (char.IsLetterOrDigit(c))
                resultBuilder.Append(char.ToLower(c));
        }
        return resultBuilder.ToString();
    }
}