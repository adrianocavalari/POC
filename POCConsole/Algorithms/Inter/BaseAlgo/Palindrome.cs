using Shouldly;

namespace POCConsole.Inter
{
    public class Palindrome
    {
        public static void Exec()
        {
            Find("bab").ShouldBe("bab");
            Find("aewbabf").ShouldBe("bab");
            Find("aewbabfj").ShouldBe("bab");
            Find("cbbd").ShouldBe("bb");
            Find("ac").ShouldBe("a");
            Find("bb").ShouldBe("bb");
            Find("abb").ShouldBe("bb");
            Find("a").ShouldBe("a");
        }

        private static string Find(string s)
        {
            var n = s.Length;
            if (n <= 1) return s;

            var largest = "";

            for (int i = 0; i < n; i++)
            {
                GetPalindrome(s, i, i, ref largest);
                GetPalindrome(s, i, i+1, ref largest);
            }

            return largest;
        }

        static void GetPalindrome(string s, int left, int right, ref string largest)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }

            var result = s[++left..right];

            if (result.Length > largest.Length)
                largest = result;
        }
    }
}
