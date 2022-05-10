using BenchmarkDotNet.Attributes;

namespace POCConsole
{
    [MemoryDiagnoser]
    public class PerformanceTest
    {
        readonly List<int> list;
        readonly int[] array;

        const int times = 10000;

        public PerformanceTest()
        {
            list = new List<int>();
            array = new int[times];

            for (var i = 0; i < times; i++)
            {
                list.Add(i);
                array[i] = i;
            }
        }

        [Benchmark]
        public void TestForInList()
        {
            for (var i = 0; i < list.Count; i++)
            {
                Console.Write(i);
            }
        }

        [Benchmark]
        public void TestForEachInList()
        {
            foreach (var l in list)
            {
                Console.Write(l);
            }
        }

        [Benchmark]
        public void TestForEachListInList()
        {
            list.ForEach(l =>
            {
                Console.Write(l);
            });
        }

        [Benchmark]
        public void TestForInArray()
        {
            for (var i = 0; i < array.Length; i++)
            {
                Console.Write(i);
            }
        }

        [Benchmark]
        public void TestForEachInArray()
        {
            foreach (var l in array)
            {
                Console.Write(l);
            }
        }

        [Benchmark]
        public void TestForEachListInArray()
        {
            array.ToList().ForEach(l =>
            {
                Console.Write(l);
            });
        }
    }
}
