using Shouldly;

namespace POCConsole.Course.MCI
{
    //O(n logn)
    //Most efficient sort
    public class QuickSort
    {
        public static void Exec()
        {
            QuickSortExec2(
                new[] { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 })
                .DumpList()
                .ShouldBe(new[] { 0, 1, 2, 4, 5, 6, 44, 63, 87, 99, 283 });
        }

        private static int[] QuickSortExec2(int[] array)
        {
            return Sort2(array, 0, array.Length-1);
        }

        public static int[] Sort2(int[] array, int low, int high)
        {
            var i = low;
            var j = high;
            var pivot = array[low];

            while(i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    (array[i], array[j]) = (array[j], array[i]);
                    i++;
                    j--;
                }
            }

            if (low < j)
                Sort2(array, low, j);
            
            if(i < high)
                Sort2(array, i, high);

            return array;
        }

        public static int[] Sort(int[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];
            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    (array[i], array[j]) = (array[j], array[i]);

                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                Sort(array, leftIndex, j);
            if (i < rightIndex)
                Sort(array, i, rightIndex);
            return array;
        }

        private static int[] QuickSortExec(int[] array)
        {
            //return Sort(array, 0, array.Length - 1);
            return SortWithPartition(array, 0, array.Length - 1);
        }

        static int[] SortWithPartition(int[] array, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(array, low, high);

                //3. Recursively continue sorting the array
                SortWithPartition(array, low, partitionIndex - 1);
                SortWithPartition(array, partitionIndex + 1, high);
            }

            return array;
        }

        static int Partition(int[] array, int low, int high)
        {
            //1. Select a pivot point.
            int pivot = array[high];

            int lowIndex = low;

            //2. Reorder the collection.
            for (int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    (array[j], array[lowIndex]) = (array[lowIndex], array[j]);
                    lowIndex++;
                }
            }

            (array[high], array[lowIndex]) = (array[lowIndex], array[high]);

            return lowIndex;
        }
    }
}
