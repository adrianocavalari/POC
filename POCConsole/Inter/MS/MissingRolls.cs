using Shouldly;

namespace POCConsole.Inter
{
    /*
        You have just rolled a dice several times. The N roll results that you remember are described by an array A. 
            However, there are Frolls whose results you have forgotten. The arithmetic mean of all of the roll results (the sum of all the roll results divided by the number of rolls) equals M.

        What are the possible results of the missing rolls?

        Write a function:

        class Solution (public int[] solution(int[] A, Int F, int H); }

        that, given an array A of length N, an integer F and an integer M, retums an array containing possible results of the missed rolls. 
            The returned array should contain F integers from 1 to 6 (valid dice rolls). If such an array does not exist then the function should return (0)

        Examples:

        1. Given A = [3, 2, 4, 3], F= 2, M = 4, your function should return (6, 6]. The arithmetic mean of all the rolls is (3+2+4+3+6 +6)/6=24/6=4.

        2. Given A = [1,5,6], F = 4, M = 3, your function may return [2, 1, 2, 4] or [6, 1, 1, 1] (among others). 3. Given A = [1, 2, 3, 4], F=4, M=6, your function should retum [0]. 
            It is not possible to obtain such a mean.

        4. Given A = [6, 1], F=1, M = 1, your function should return [0]. It is not possible to obtain such a mean.

        Write an efficient algorithm for the following assumptions:

        N and F are integers within the range (1.100,000); each element of array A is an integer within the range [1.6 Mis an integer within the range [1..6).

        Remember, all submissions are being checked for plagiarism. Your recruiter will be informed in case suspicious activity is

        detected. Copyright 2000-2022 by Codility Limited. All Rights Reserved. Unauthorized onpying, publication or disclosure

     */
    public class MissingRolls
    {
        public static void Exec()
        {
            Solution(new int[] { 3, 2, 4, 3 }, 2, 4).DumpList(); // 6,6

            Solution(new int[] { 1, 5, 6 }, 4, 3).DumpList(); // 2,1,2,4 or 6,1,1,1

            Solution(new int[] { 1, 2, 3, 4 }, 4, 6).DumpList(); // 0

            Solution(new int[] { 6, 1 }, 1, 1).DumpList(); // 0
        }

        public static int[] Solution(int[] A, int F, int M)
        {
            int rolled = A.Length + F;
            int totalSum = rolled * M;

            int remaining = totalSum - GetTotal(A);
            int max = F * 6;

            if (remaining > max || remaining < 1)
                return new int[] { 0 };

            return GetResult(remaining);
        }

        private static int[] GetResult(int remaining)
        {
            var result = new List<int>();
            while (remaining > 0)
            {
                if (remaining >= 6)
                {
                    result.Add(6);
                    remaining -= 6;
                }
                else
                {
                    result.Add(1);
                    remaining--;
                }
            }

            return result.ToArray();
        }

        private static int GetTotal(int[] A)
        {
            int diceSum = 0;
            foreach (int sum in A)
            {
                diceSum += sum;
            }

            return diceSum;
        }

        ////public static int[] getPossibleDiceRoll(int[] A, int F, int M)
        ////{
        ////    int rolled = A.Length + F;
        ////    int totalSum = rolled * M;

        ////    int diceSum = 0;
        ////    foreach (int sum in A)
        ////    {
        ////        diceSum += sum;
        ////    }

        ////    int remainingSum = totalSum - diceSum;
        ////    int maxPossible = F * 6;
        ////    if (remainingSum > maxPossible)
        ////        return new int[] { 0 };

        ////    var result = new List<int>();
        ////    while (remainingSum >= 6)
        ////    {
        ////        result.Add(6);
        ////        remainingSum -= 6;
        ////    }

        ////    if (remainingSum > 0)
        ////        result.Add(remainingSum);

        ////    return result.ToArray();
        ////}



        #region Third
        //static void Main(string[] args)
        //{
        //    //var res = Test("babaa");
        //    //res.ShouldBe(3);

        //    //var res2 = Test("bbbab");
        //    //res2.ShouldBe(4);

        //    //var res3 = Test("bbbaaabbb");
        //    //res3.ShouldBe(0);

        //    //var res4 = Test("abbbb");
        //    //res4.ShouldBe(3);

        //    //var res5 = Test("abbabbbaaaa");
        //    //res5.ShouldBe(9);

        //    int sum = solution(new[] { 6, 1, 4, 6, 3, 2, 7, 4 }, 3, 2);
        //    Console.WriteLine(sum);
        //    sum.ShouldBe(24);
        //    int sum2 = solution(new[] { 10, 19, 15 }, 2, 2);
        //    Console.WriteLine(sum2);
        //    sum2.ShouldBe(-1);

        //    int sum3 = solution(new[] { 10, 25, 15, 5 }, 2, 2);
        //    Console.WriteLine(sum3);
        //    sum3.ShouldBe(55);
        //}

        //static int solution(int[] A, int K, int L)
        //{
        //    if (A.Length < K + L)
        //        return -1;

        //    if (A.Length == K + L)
        //        return A.Sum();

        //    var map = new Dictionary<int, int>();
        //    for (int i = 0; i < A.Length - K + 1; i++)
        //    {
        //        Sum(A, K, map, i);
        //    }

        //    int maxValue = map.Values.Max();
        //    var key = new List<int>();
        //    foreach (var entry in map)
        //    {

        //        if (maxValue.Equals(entry.Value))
        //        {
        //            key.Add(entry.Key);
        //        }
        //    }

        //    int[] temp = A;

        //    var map2 = new Dictionary<int, int>();
        //    var sums = new List<int>();

        //    for (int k = 0; k < key.Count; k++)
        //    {
        //        for (int i = key[k]; i < key[k] + K; i++)
        //        {
        //            temp[i] = 0;
        //        }
        //        for (int i = 0; i < temp.Count() - L + 1; i++)
        //        {
        //            Sum(temp, L, map2, i);
        //        }
        //        int maxValue2 = map2.Values.Max();
        //        sums.Add(maxValue2 + maxValue);
        //    }

        //    return sums.Max();
        //}

        //private static void Sum(int[] A, int K, Dictionary<int, int> map, int i)
        //{
        //    int sum = 0;
        //    for (int j = i; j < K + i; j++)
        //    {
        //        sum += A[j];
        //    }
        //    map.Add(i, sum);
        //}


        ////public int FindMaximumApples(int[] A, int k, int l)
        ////{
        ////    int ans1 = FindMaximumApplesImpl(A, k, l);
        ////    int ans2 = FindMaximumApplesImpl(A, l, k);
        ////    return Math.Max(ans1, ans2);

        ////}

        ////private int FindMaximumApplesImpl(int[] A, int k, int l)
        ////{

        ////    if (k + l > A.Length)
        ////    {
        ////        return -1;
        ////    }

        ////    var sum = new int[1000];

        ////    sum[0] = A[0];

        ////    for (int i = 1; i < A.Length; i++)
        ////    {
        ////        sum[i] = sum[i - 1] + A[i];
        ////    }

        ////    int max = -1;
        ////    int x = 0, y = 0;

        ////    for (int a = 0; a + k - 1 < A.Length; a++)
        ////    {
        ////        if (a > 0)
        ////            x = sum[a + k - 1] - sum[a - 1];
        ////        else
        ////            x = sum[a + k - 1];

        ////        for (int b = a + k; b + l - 1 < A.Length; b++)
        ////        {
        ////            if (b > 0)
        ////                y = sum[b + l - 1] - sum[b - 1];
        ////            else
        ////                y = sum[b + l - 1];
        ////            if (x + y > max)
        ////            {
        ////                max = x + y;
        ////            }
        ////        }
        ////    }
        ////    return max;
        ////}
        #endregion
    }
}
