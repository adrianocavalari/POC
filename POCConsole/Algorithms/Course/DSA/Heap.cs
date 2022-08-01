using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Mosh
/// </summary>
namespace POCConsole.Course.DSA
{
    public class Heap
    {
        private int[] items = new int[10];
        private int count = 0;

        public static void Exec()
        {
            var heap = new Heap();

            heap.Insert(10);
            heap.Insert(5);
            heap.Insert(17);
            heap.Insert(4);
            heap.Insert(22);
        }

        public void Insert(int value)
        {
            if (IsFull())
                throw new InvalidOperationException();

            items[count++] = value;
            BubbleUp();
        }

        public void Remove()
        {
            items[0] = items[--count];

            var index = 0;

            while (items[index] < items[GetLeft(index)]
                && items[index] < items[GetRight(index)])
            {

            }
        }

        public bool IsFull()
        {
            return count == items.Length;
        }

        private void BubbleUp()
        {
            var index = count - 1;
            var partentIndex = GetPartentIndex(index);
            while (index > 0 && items[index] > items[partentIndex])
            {
                (items[partentIndex], items[index]) = (items[index], items[partentIndex]);
                index = GetPartentIndex(index);
                partentIndex = GetPartentIndex(index);
            }
        }

        private static int GetPartentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private static int GetLeft(int index)
        {
            return (index * 2) + 1;
        }

        private static int GetRight(int index)
        {
            return (index * 2) + 2;
        }
    }
}
