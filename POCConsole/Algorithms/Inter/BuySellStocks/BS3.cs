using Shouldly;

namespace POCConsole.Inter.BuySellStocks
{
    //https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii/
    //https://www.youtube.com/watch?v=Pw6lrYANjz4

    public class BS3
    {
        public static void Exec()
        {
            MaxProfit(new[] { 3, 5, 1, 4 }).ShouldBe(6);
            //MaxProfit(new[] { 1, 2, 3, 4, 5 }).ShouldBe(4);
            //MaxProfit(new[] { 7, 6, 4, 3, 1 }).ShouldBe(0);
        }

        static int MaxProfit(int[] prices)
        {
            int buy1 = int.MinValue, buy2 = int.MinValue;
            int sell1 = 0, total = 0;

            foreach (var i in prices)
            {
                buy1 = Math.Max(buy1, -i);          // How much I paid

                sell1 = Math.Max(sell1, buy1 + i);  // Profit

                buy2 = Math.Max(buy2, sell1 - i);   // Profit

                total = Math.Max(total, buy2 + i);  // Total
            }

            return total;
        }
    }
}
