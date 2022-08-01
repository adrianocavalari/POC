using Shouldly;
using System.Numerics;

namespace POCConsole.Course.MCI
{
    //       (2) -- (0)
    //     /    \
    //   (1) -- (3)

    public class GraphsTypes
    {
        public static void Exec()
        {
            //Edge list
            var edgeList = new List<int[]> {
                 new[] { 0, 2 }
                ,new[] { 2, 3 }
                ,new[] { 2, 1 }
                ,new[] { 1, 3 }
            };

            //Adjacent list
            var adjacentList = new List<int[]> {
                 new[] { 2 }
                ,new[] { 2, 3 }
                ,new[] { 0,1,2}
                ,new[] { 1, 2 }
            };

            //Adjacent Matrix
            var adjacentMatrix = new List<int[]> {
                 new[] { 0, 0, 1, 0 }
                ,new[] { 0, 0, 1, 1 }
                ,new[] { 1, 1, 0, 1 }
                ,new[] { 0, 1, 1, 0 }
            };
        }
    }
}
