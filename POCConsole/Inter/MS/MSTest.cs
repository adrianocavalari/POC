using Shouldly;

namespace POCConsole.Inter
{

    public class MSTest
    {
        public static void Exec()
        {
            var res = Test("babaa");
            res.ShouldBe(3);

            var res2 = Test("bbbab");
            res2.ShouldBe(4);

            var res3 = Test("bbbaaabbb");
            res3.ShouldBe(0);

            var res4 = Test("abbbb");
            res4.ShouldBe(3);

            var res5 = Test("abbabbbaaaa");
            res5.ShouldBe(9);
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
                    totalSmaller = totalSmaller + total - count;
                    count = 1;
                }
            }
            return totalSmaller + total - count;
        }

        ////static int Test(string S)
        ////{
        ////    int maxcount = 1;
        ////    int count = 1;
        ////    for (int i = 1; i < S.Length; i++)
        ////    {
        ////        if (S[i] != S[i - 1])
        ////        {
        ////            maxcount = Math.Max(maxcount, count);
        ////            count = 1;
        ////        }
        ////        else
        ////        {
        ////            count++;
        ////        }
        ////    }

        ////    maxcount = Math.Max(maxcount, count);
        ////    count = 1;
        ////    int res = 0;
        ////    for (int i = 1; i < S.Length; i++)
        ////    {
        ////        if (S[i] != S[i - 1])
        ////        {
        ////            res = res + maxcount - count;
        ////            count = 1;
        ////        }
        ////        else
        ////        {
        ////            count++;
        ////        }
        ////    }
        ////    res = res + maxcount - count;
        ////    return res;
        ////}


        #region Second
        //static void Main(string[] args)
        //{
        //    var res = Test("babaa");
        //    res.ShouldBe(3);

        //    var res2 = Test("bbbab");
        //    res2.ShouldBe(4);

        //    var res3 = Test("bbbaaabbb");
        //    res3.ShouldBe(0);

        //    var res4 = Test("abbbb");
        //    res4.ShouldBe(3);

        //    var res5 = Test("abbabbbaaaa");
        //    res5.ShouldBe(9);

        //    var result = solution(new int[] { 3, 2, 4, 3 }, 2, 4); // 6,6
        //    foreach (int res in result)
        //        Console.Write(res + " ");

        //    var result1 = solution(new int[] { 1, 5, 6 }, 4, 3); // 2,1,2,4 or 6,1,1,1
        //    foreach (int res in result1)
        //        Console.Write(res + " ");

        //    var result2 = solution(new int[] { 1, 2, 3, 4 }, 4, 6); // 0
        //    foreach (int res in result2)
        //        Console.Write(res + " ");

        //    var result3 = solution(new int[] { 6, 1 }, 1, 1); // 0
        //    foreach (int res in result3)
        //        Console.Write(res + " ");
        //}

        //public static int[] solution(int[] A, int F, int M)
        //{
        //    int rolled = A.Length + F;
        //    int totalSum = rolled * M;

        //    int remaining = totalSum - GetTotal(A);
        //    int max = F * 6;

        //    if (remaining > max || remaining < 1)
        //        return new int[] { 0 };

        //    return GetResult(remaining);
        //}

        //private static int[] GetResult(int remaining)
        //{
        //    var result = new List<int>();
        //    while (remaining > 0)
        //    {
        //        if (remaining >= 6)
        //        {
        //            result.Add(6);
        //            remaining -= 6;
        //        }
        //        else
        //        {
        //            result.Add(1);
        //            remaining--;
        //        }
        //    }

        //    return result.ToArray();
        //}

        //private static int GetTotal(int[] A)
        //{
        //    int diceSum = 0;
        //    foreach (int sum in A)
        //    {
        //        diceSum += sum;
        //    }

        //    return diceSum;
        //}

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


        #endregion

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
