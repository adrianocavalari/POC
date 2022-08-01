using Shouldly;
using System.Text;

namespace POCConsole.Inter.BaseAlgo
{
    //https://www.rapidtables.com/convert/number/decimal-to-binary.html

    public class BinaryCalc
    {
        //  Divide number per 2 if rest add 1 otherwise 0, Binary from bottom to top
        //  153/2     1 ^   
        //  76/2  	  0 |
        //  38/2	  0 |
        //  19/2	  1 |
        //  9/2       1 |
        //  4/2       0 |
        //  2/2       0 |
        //  1/2       1 | Binary of 153 = 10011001

        //  Reverse - 2^0 = 1
        //  10011001  
        //  2^7+0+0+2^5+2^4+0+0+2
        //  2^7+2^4+2^3+2^0
        //  2*2*2*2*2*2*2= 128 + 2*2*2*2 = 16 + 2*2*2 = 8 + 2^0 = 1 
        //  128 + 16 + 8 + 1 = 153
        //  
        //  ---------------------------------------

        //  10011.011
        //  2^4+0+0+2^1+2^0+0+1/4+1/8
        //  2^4+2^1+2^0+1/4+1/8
        //  16+2+1+0.25+0.125
        //  19.375
        //  
        public static void Exec()
        {
            AddBinary("0", "0").ShouldBe("0"); // 3 + 1 = 4
            AddBinary("0", "1").ShouldBe("1"); // 3 + 1 = 4
            AddBinary("11", "1").ShouldBe("100"); // 3 + 1 = 4
            AddBinary("1010", "1011").ShouldBe("10101"); // 10 + 11 = 21
            AddBinary("1100100", "110101").ShouldBe("10011001"); // 100 + 53 = 153

        }

        static string AddBinary(string a, string b)
        {
            StringBuilder sb = new();
            int i = a.Length - 1, j = b.Length - 1, carry = 0;
            while (i >= 0 || j >= 0)
            {
                if (i >= 0)
                    carry += a[i--] - '0';
                if (j >= 0)
                    carry += b[j--] - '0';

                sb.Insert(0, carry % 2);
                carry /= 2;
            }

            return carry == 0 ? sb.ToString() : carry + sb.ToString();
        }
    }
}
