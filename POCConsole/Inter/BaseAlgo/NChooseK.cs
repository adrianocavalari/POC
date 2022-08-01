using Shouldly;
using System.Text;

namespace POCConsole.Inter.BaseAlgo
{
    //https://www.youtube.com/watch?v=Hmld7MhFUDk
    //https://www.youtube.com/watch?v=OcO2SgAnvhg

    public class NChooseK
    {
        public static void Exec()
        {
            int n = 4, k = 2;

            // Find number of permutation, orders matters
            // Elect president and vice president from a group of 4
            // {A, B, C, D} =   {A, B}, {A, C}, {A, D}
            //                  {B, A}, {B, C}, {B, D}
            //                  {C, A}, {C, B}, {C, D}
            //                  {D, A}, {D, B}, {D, C}
            var p = factorial(n) / factorial(n - k);

            // Find number of combination, orders does not matters
            // Different possibilities to choose 2 people from the group (A,B,C,D)
            // How many different bouquets can she does from 4 different types of flower with 2 flowers in the arrangement (A,B,C,D)
            // {A, B, C, D} = {A, B, C}, {B, C, D}, {A, C, D}, {A, B, D}
            var a = factorial(n) / (factorial(k) * factorial(n - k));

            var b = combination(n, k);

            var c = GetBinCoeff(n, k);
        }

        static int factorial(int x)
        {
            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                result = result * i;
            }
            return result;
        }

        public static long combination(long n, long k)
        {
            double sum = 0;
            for (long i = 0; i < k; i++)
            {
                sum += Math.Log10(n - i);
                sum -= Math.Log10(i + 1);
            }
            return (long)Math.Pow(10, sum);
        }

        public static long GetBinCoeff(long N, long K)
        {
            // This function gets the total number of unique combinations based upon N and K.
            // N is the total number of items.
            // K is the size of the group.
            // Total number of unique combinations = N! / ( K! (N - K)! ).
            // This function is less efficient, but is more likely to not overflow when N and K are large.
            // Taken from:  http://blog.plover.com/math/choose.html
            //
            long r = 1;
            long d;
            if (K > N) return 0;
            for (d = 1; d <= K; d++)
            {
                r *= N--;
                r /= d;
            }
            return r;
        }
    }
}
