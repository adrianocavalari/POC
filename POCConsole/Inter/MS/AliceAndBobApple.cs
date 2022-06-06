using Shouldly;

namespace POCConsole.Inter
{
    //https://www.lintcode.com/problem/1850/

    public class AliceAndBobApple
    {
        public static void Exec()
        {
            solution(new[] { 6, 1, 4, 6, 3, 2, 7, 4 }, 3, 2)
                .Dump()
            .ShouldBe(24);

            solution(new[] { 15, 35, 6, 1, 4, 6, 3, 2, 7, 4, 20, 30, 50 }, 3, 2)
                .Dump()
            .ShouldBe(150);

            solution(new[] { 6, 1, 15, 35, 4, 4, 20, 30, 50, 6, 3, 2, 7 }, 5, 4)
                .Dump();
            //.ShouldBe(150);

            //int sum2 = solution(new[] { 10, 19, 15 }, 2, 2);
            //Console.WriteLine(sum2);
            //sum2.ShouldBe(-1);

            //int sum3 = solution(new[] { 10, 25, 15, 5 }, 2, 2);
            //Console.WriteLine(sum3);
            //sum3.ShouldBe(55);

            //int sum4 = solution(new[] { 10, 25, 1, 15, 5 }, 2, 2);
            //Console.WriteLine(sum4);
            //sum4.ShouldBe(55);

            //int sum5 = solution(new[] { 10, 1, 25, 5, 15, 1, 5 }, 2, 2);
            //Console.WriteLine(sum5);
            //sum5.ShouldBe(46);

            //int sum6 = solution(new[] { 10, 5, 25, 2, 15, 1, 5 }, 3, 2);
            //Console.WriteLine(sum6);
            //sum6.ShouldBe(57);

            //int sum7 = solution(new[] { 15, 5, 1, 2, 15, 15, 25 }, 3, 2);
            //Console.WriteLine(sum7);
            //sum7.ShouldBe(75);

            //int sum8 = solution(new[] { 1, 2, 3, 4, 5, 6 }, 3, 2);
            //Console.WriteLine(sum8);
            //sum8.ShouldBe(20);

            //solution(new[] { 3, 2, 1, 4, 5, 6 }, 3, 2)
            //    .Dump();
            //.ShouldBe(20);
        }

        static int solution(int[] A, int K, int L)
        {

            //return FindMy(A, K, L);

            //return FindMaximumApples(A, K, L);

            //return Find2(A, K, L);

            //return Find3(A, K, L);

            //return PickApples4(A, K, L);

            return Find3(A, K, L);
        }

        static int FindMy(int[] A, int K, int L)
        {
            if (A.Length < K + L)
                return -1;

            if (A.Length == K + L)
            {
                var sum = 0;

                for (int i = 0; i < A.Length; i++)
                {
                    sum += A[i];
                }

                return sum;
            }

            var maxK = int.MinValue;
            var maxL = int.MinValue;
            var sumK = 0;
            var sumL = 0;
            var kAdjusted = K - 1;
            var lAdjusted = L - 1;
            var li = K;

            var dic = new Dictionary<int, int>();
            for (int i = 0; i < A.Length; i++)
            {
                sumK += A[i];

                if (i >= kAdjusted)
                {
                    maxK = Math.Max(sumK, maxK);
                    sumK -= A[i - kAdjusted];
                }

                if (i > lAdjusted && i + K >= A.Length)
                {
                    li = 0;
                    sumL = 0;

                    if (li < A.Length)
                    {
                        sumL += A[li] + A[li + 1];

                        if (li > K)
                        {
                            maxL = Math.Max(sumL, maxL);
                            sumL -= A[li - i];
                        }
                    }
                }
                else
                {
                    li = i + K;
                    if (li < A.Length)
                    {
                        sumL += A[li];

                        if (li > K)
                        {

                            maxL = Math.Max(sumL, maxL);
                            sumL -= A[li - i];
                        }
                    }
                }



            }

            return maxK + maxL;
        }

        static int FindMaximumApples(int[] A, int k, int l)
        {
            int ans1 = FindMaximumApplesImpl(A, k, l);
            int ans2 = FindMaximumApplesImpl(A, l, k);
            return Math.Max(ans1, ans2);

        }

        static int FindMaximumApplesImpl(int[] A, int k, int l)
        {

            if (k + l > A.Length)
            {
                return -1;
            }

            var sum = new int[1000];

            sum[0] = A[0];

            for (int i = 1; i < A.Length; i++)
            {
                sum[i] = sum[i - 1] + A[i];
            }

            int max = -1;
            int x = 0, y = 0;

            for (int a = 0; a + k - 1 < A.Length; a++)
            {
                if (a > 0)
                    x = sum[a + k - 1] - sum[a - 1];
                else
                    x = sum[a + k - 1];

                for (int b = a + k; b + l - 1 < A.Length; b++)
                {
                    if (b > 0)
                        y = sum[b + l - 1] - sum[b - 1];
                    else
                        y = sum[b + l - 1];
                    if (x + y > max)
                    {
                        max = x + y;
                    }
                }
            }
            return max;
        }

        static int Find2(int[] apples, int K, int L)
        {
            if (K + L > apples.Length) return -1;
            int n = apples.Length;
            int[] pre = new int[n];   // prefix array

            // 0 1  2   3   4   5   6   7
            // 6 1  4   6   3   2   7   4
            // 6 7 11  17  20  22  29  32
            for (int i = 0; i < n; i++)
            {
                pre[i] = i == 0
                    ? apples[i]
                    : apples[i] + pre[i - 1];
            }

            var dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[n];

                for (int j = i + L - 1; j < n; j++)
                {
                    // e.g. L = 4
                    // dp[2][6]   => dp[2][5]  or  dp[3][6]
                    dp[i][j] = j == L - 1
                        ? pre[j]
                        : Math.Max(dp[i][j - 1], pre[j] - pre[j - L]);
                }
            }

            // 6 1  4   6   3
            // 6 7 11   17 20
            int res = 0;
            for (int i = 0; i + K - 1 < n; i++)
            {
                int A = i == 0
                    ? pre[i + K - 1]
                    : pre[i + K - 1] - pre[i - 1];

                int B = Math.Max(i == 0
                                    ? 0
                                    : dp[0][i - 1],
                                i + K > n - 1
                                    ? 0
                                    : dp[i + K][n - 1]);

                res = Math.Max(res, A + B);
            }
            return res;
        }


        /// <summary>
		///	Provide a simple idea, the code is slightly shorter
		///	
		///	Ideas:
		///	
		///	Interval sum first thought prefix sum fast solution
		///	Because they do not interfere with each other, consider the partition and divide it into two parts: left and right
		///	Because the intervals of L and K are continuous, each split point is enumerated by right shifting, and divided into two parts [i-L:i] and [i:i+L].
		///	max(max(left window sum) current right window sum) is the result
		///	Special Considerations:
		///	
		///	The lengths of K and L are different, and the interval of the left and right parts that can be divided will also be different.
		///	So you need to consider left K, right L and left L, right K.
		///	So basically the same code, copy K and L to correct.
		///	the complexity:
		///	
		///	Time: O(n)
		///	Space: O(n)
        /// </summary>
        static int Find3(int[] A, int K, int L)
        {
            ///Entry { 3, 2, 1, 4, 5, 6 }, 3, 2

            //7
            var n = A.Length + 1;
            var prefix_sum = new int[n];

            //[0, 3, 5, 6, 10, 15, 21]
            for (int i = 1; i < n; i++)
                prefix_sum[i] = prefix_sum[i - 1] + A[i - 1];

            prefix_sum.DumpList();

            return Math.Max(SumLeftRight(prefix_sum, K, L), SumLeftRight(prefix_sum, L, K));
        }

        static int SumLeftRight(int[] prefix_sum, int L, int K)
        {
            var rightSum = -1;
            var leftSum = 0;

            for (int i = L; i < prefix_sum.Length - K; i++) // From 2 to 3
            {
                i.Dump($"i: ");

                var current = prefix_sum[i];
                //current.Dump($"L current: ");

                $" {current} - {prefix_sum[i - L]} = {current - prefix_sum[i - L]}".Dump();
                leftSum = Math.Max(leftSum, current - prefix_sum[i - L]);
                //leftSum.Dump($"L leftSum: ");

                $" {leftSum} + {prefix_sum[i + K]} - {current} = {leftSum + prefix_sum[i + K] - current}".Dump();
                rightSum = Math.Max(rightSum, leftSum + prefix_sum[i + K] - current);
                //rightSum.Dump($"L rightSum: ");
            }

            return rightSum;
        }

        static int PickApples4(int[] A, int K, int L)
        {
            if (A == null || A.Length < K + L)
            {
                return -1;
            }

            int n = A.Length;
            int[] prefixSum = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                prefixSum[i + 1] = prefixSum[i] + A[i];
            }

            int[] prefixSumMaxOfK = new int[n];
            int max = 0;
            for (int i = K - 1; i < n; i++)
            {
                max = Math.Max(max, prefixSum[i + 1] - prefixSum[i - K + 1]);
                prefixSumMaxOfK[i] = max;
            }

            int[] postfixSumMaxOfL = new int[n];
            max = 0;
            for (int i = n - L; i >= 0; i--)
            {
                max = Math.Max(max, prefixSum[i + L] - prefixSum[i]);
                postfixSumMaxOfL[i] = max;
            }

            int[] prefixSumMaxOfL = new int[n];
            max = 0;
            for (int i = L - 1; i < n; i++)
            {
                max = Math.Max(max, prefixSum[i + 1] - prefixSum[i - L + 1]);
                prefixSumMaxOfL[i] = max;
            }

            int[] postfixSumMaxOfK = new int[n];
            max = 0;
            for (int i = n - K; i >= 0; i--)
            {
                max = Math.Max(max, prefixSum[i + K] - prefixSum[i]);
                postfixSumMaxOfK[i] = max;
            }

            max = 0;
            for (int i = 0; i < n - 1; i++)
            {
                max = Math.Max(
                    max, Math.Max(
                        (prefixSumMaxOfK[i] + postfixSumMaxOfL[i + 1]),
                        (prefixSumMaxOfL[i] + postfixSumMaxOfK[i + 1])
                    )
                );
            }
            return max;
        }


        static int PickApples5(int[] nums, int k, int l)
        {
            int result = -1;
            // check corner cases
            if (nums == null || nums.Length == 0)
            {
                return result;
            }

            int size = nums.Length;
            if (size < k + l)
            {
                return result;
            }

            // normal case
            int[] preSum = new int[size + 1];
            for (int i = 0; i < size; i++)
            {
                preSum[i + 1] = preSum[i] + nums[i];
            }

            // scanning by [k-left, l-right] windows
            for (int i = 0; i < size - l; i++)
            {
                if (i + k > size)
                {
                    break;
                }
                int kLeftSum = getRange(preSum, i, i + k);

                int lRightSum = 0;
                for (int j = i + k; j < size - l + 1; j++)
                {
                    int currentLRightSum = getRange(preSum, j, j + l);
                    lRightSum = Math.Max(lRightSum, currentLRightSum);
                }

                result = Math.Max(result, kLeftSum + lRightSum);
            }

            // scanning by [l-left, k-right] windows
            for (int i = 0; i < size - k; i++)
            {
                if (i + l > size)
                {
                    break;
                }
                int lLeftSum = getRange(preSum, i, i + l);

                int kRightSum = 0;
                for (int j = i + l; j < size - k + 1; j++)
                {
                    int currentKRightSum = getRange(preSum, j, j + k);
                    kRightSum = Math.Max(kRightSum, currentKRightSum);
                }

                result = Math.Max(result, lLeftSum + kRightSum);
            }

            // return 
            return result;
        }

        // helper method
        static int getRange(int[] preSum, int i, int j)
        {
            if (j > preSum.Length)
            {
                return 0;
            }
            return preSum[j] - preSum[i];
        }

    }
}
/*
Alice and Bob work in a beautiful orchard. There are N apple trees in the orchard. The apple trees are arranged in a row and

they are numbered from 1 to N.

Alice is planning to collect all the apples from K consecutive trees and Bob is planning to collect all the apples from L consecutive trees. They want to choose two disjoint segments 
(one consisting of K trees for Alice and the other consisting of L trees for Bob) so as not to disturb each other. What is the maximum number of apples that they can collect? Write a function:

class Solution (public int solution(int[] A. iot K. int L); )

that, given an array A consisting of N integers denoting the number of apples on each apple tree in the row, and integers K

and L denoting, respectively, the number of trees that Alice and Bob can choose when collecting, returns the maximum

number of apples that can be collected by them, or -1 if there are no such intervals.

For example, given A = 16, 1, 4, 6, 3, 2, 7, 41, K-3, L-2, your function should return 24, because Alice can choose trees 3 to 5 and collect 4+6+3=13 apples, and Bob can choose trees 7 to 8 and collect 7+4=11 apples. Thus, they will collect 13+

11-24 apples in total, and that is the maximum number that can be achieved. Given A-[10, 19, 15), K=2, L-2, your function should return-1, because it is not possible for Alice and

disjoint intervals.

Assume that

N is an integer within the range [2..100): K and L are integers within the range [1N1) each element of array A is an integer within the range [1.500)

In your solution, focus on correctness. The performance of your solution will not be the focus of the assessment. Copyright 2009-2022 by Codlity Limited. All Rights Reserved. Unauthorized copying, publication or disclosure prohibited
*/