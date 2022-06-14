using Shouldly;

namespace POCConsole.Inter.BuySellStocks
{
    //https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii/

    public class BS1
    {
        public static void Exec()
        {
            MaxProfit(new[] { 3, 5, 1, 4 }).ShouldBe(3);
            //MaxProfit(new[] { 1, 2, 3, 4, 5 }).ShouldBe(4);
            //MaxProfit(new[] { 7, 6, 4, 3, 1 }).ShouldBe(0);
        }

        static int MaxProfit(int[] prices)
        {
            int buy = int.MinValue;
            int profit = 0;

            foreach (var i in prices)
            {
                buy = Math.Max(buy, -i);          // How much I paid

                profit = Math.Max(profit, buy + i);  // Profit
            }

            return profit;
        }
    }
}
