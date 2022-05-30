namespace POCConsole.ArrayTests
{
    public class MyArray
    {
        private int[] items;
        private int count;

        public MyArray(int length)
        {
            items = new int[length];
        }

        public void Insert(int item)
        {
            if (count == items.Length)
            {
                var newItems = new int[count * 2];

                for (int i = 0; i < count; i++)
                {
                    newItems[i] = items[i];
                }

                items = newItems;
            }

            items[count++] = item;
        }

        public void RemoveAt(int index)
        {
            if((index < 0) || (index >= count))
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            for (int i = index; i < count; i++)
            {
                items[i] = items[i + 1];
            }

            count--;
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i] == item)
                    return i;
            }

            return -1;
        }

        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(items[i]);
            }
        }
    }
}
