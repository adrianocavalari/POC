using Shouldly;

namespace POCConsole.Inter.BuySellStocks
{
    //https://leetcode.com/problems/number-of-islands/

    public class NumIslands
    {
        public static void Exec()
        {
            GetIsland(new char[][] {
                "11110".ToCharArray(),
                "11010".ToCharArray(),
                "11000".ToCharArray(),
                "00000".ToCharArray(),
            }).ShouldBe(1);

            GetIsland(new char[][] {
                "11000".ToCharArray(),
                "11000".ToCharArray(),
                "00100".ToCharArray(),
                "00011".ToCharArray(),
            }).ShouldBe(3);
        }

        static int GetIsland(char[][] grid)
        {
            // 0,0 check right till find 0, check down till 0
            // if find 1 mark as 0 and performe DFS to all sides ++ --
            //Console.WriteLine(grid[0].Length);

            var count = 0;
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        DFS(grid, i, j);
                        count++;
                    }

                }
            }

            return count;
        }

        static void DFS(char[][] grid, int row, int col)
        {
            if (row < 0 || col < 0 || row >= grid.Length || col >= grid[0].Length || grid[row][col] == '0')
                return;

            grid[row][col] = '0';
            DFS(grid, row + 1, col);
            DFS(grid, row - 1, col);
            DFS(grid, row, col + 1);
            DFS(grid, row, col - 1);
        }
    }
}
