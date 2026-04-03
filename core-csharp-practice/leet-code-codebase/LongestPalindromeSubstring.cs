public class LongestPalindromeSubstring
{
    public string LongestPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s))
            return "";

        int start = 0, end = 0;

        for (int i = 0; i < s.Length; i++)
        {
            int len1 = FindPalindromeString(s, i, i);     // odd length
            int len2 = FindPalindromeString(s, i, i + 1); // even length
            int len = Math.Max(len1, len2);

            if (len > end - start)
            {
                start = i - (len - 1) / 2;
                end = i + len / 2;
            }
        }

        return s.Substring(start, end - start + 1);
    }

    public int FindPalindromeString(string s, int left, int right)
    {
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            left--;
            right++;
        }
        return right - left - 1;
    }
}