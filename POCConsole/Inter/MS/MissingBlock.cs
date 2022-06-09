using Shouldly;

namespace POCConsole.Inter
{
    /*
        You are given a string S consisting of letters 'a' and/or 'b'. A block is a consecutive fragment of Scomposed of the same letters and surrounded by different letters or string endings. For example, S="abbabbaaa" has five block: "a", "bb","a", "bb" and "aaa".

        What is the minimum number of additional letters needed to obtain a string containing blocks of equal lengths? Letters can be added only at the beginning or at the end of an existing block.

        Write a function:

        class Solution { public int solution(string 5);)

        that, given a string S of length N, returns the minimum number of additional letters needed to obtain a string containing

        blocks of equal lengths.

        Examples:

        1. Given S="baba", the function should retum 3. There are four blocks "b", "a", "b", "aa". One letter each should be added to the first, second and third blocks, therefore obtaining a string "bbaabbaa", in which every block is of equal length.

        2. Given S="bbbab", the function should return 4. Two letters each should be added to the second and third blocks,

        therefore obtaining a string "bbbaaabbb", in which every block is of equal length.

        3. Given S="bbbaaabbb", the function should return 0. All blocks are already of equal lengths.

        Write an efficient algorithm for the following assumptions: N is an integer within the range [1.40,000)

        string S consists only of the characters and/or "b".

        Copyright by Codiity Limited. All Rights Reserved. Unhartzed copying, publication or discoure prohibited.

     */
    public class MissingBlock
    {
        public static void Exec()
        {
            Test("babaa").ShouldBe(3);

            Test("bbbab").ShouldBe(4);

            Test("bbbaaabbb").ShouldBe(0);

            Test("abbbb").ShouldBe(3);

            Test("abbabbbaaaa").ShouldBe(9);
        }

        static int Test(string S)
        {
            var total = GetTotalEquals(S);

            return SumSmaller(S, total);
        }

        static int GetTotalEquals(string S)
        {
            var count = 1;
            var total = 1;
            for (int i = 1; i < S.Length; i++)
            {
                if (S[i] == S[i - 1])
                {
                    count++;
                }
                else
                {
                    total = Math.Max(total, count);
                    count = 1;
                }
            }

            return Math.Max(total, count);
        }

        static int SumSmaller(string S, int total)
        {
            var count = 1;
            int totalSmaller = 0;
            for (int i = 1; i < S.Length; i++)
            {
                if (S[i] == S[i - 1])
                {
                    count++;
                }
                else
                {
                    totalSmaller += total - count;
                    count = 1;
                }
            }
            return totalSmaller + total - count;
        }

        //Original Imp
        //static int Test(string S)
        //{
        //    int maxcount = 1;
        //    int count = 1;
        //    for (int i = 1; i < S.Length; i++)
        //    {
        //        if (S[i] != S[i - 1])
        //        {
        //            maxcount = Math.Max(maxcount, count);
        //            count = 1;
        //        }
        //        else
        //        {
        //            count++;
        //        }
        //    }

        //    maxcount = Math.Max(maxcount, count);
        //    count = 1;
        //    int res = 0;
        //    for (int i = 1; i < S.Length; i++)
        //    {
        //        if (S[i] != S[i - 1])
        //        {
        //            res = res + maxcount - count;
        //            count = 1;
        //        }
        //        else
        //        {
        //            count++;
        //        }
        //    }
        //    res = res + maxcount - count;
        //    return res;
        //}
    }
}
