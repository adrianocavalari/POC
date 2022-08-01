using Shouldly;
using System.Numerics;

namespace POCConsole.Course.MCI
{
    // O(N)

    public class FibonacciWithCache
    {
        static int calculations = 0;

        public static void Exec()
        {
            var fib = Fibonacci();

            var r = fib(100);

            r.Dump();

            calculations.Dump();
        }

        private static Func<int, BigInteger> Fibonacci()
        {
            var cache = new BigInteger[101];

            BigInteger fib(int n)
            {
                calculations++;

                if (cache[n] == 0)
                {
                    if (n < 2)
                    {
                        return n;
                    }
                    else
                    {
                        cache[n] = fib(n - 1) + fib(n - 2);
                        return cache[n];
                    }
                }
                else
                {
                    return cache[n];
                }
            }

            return fib;
        }
    }
}
