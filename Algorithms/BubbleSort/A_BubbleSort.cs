namespace Algorithms
{
    public class A_BubbleSort
    {
        public void BubbleSort(int[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                var swapped = false;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        swapped = true;
                    }
                }

                if (!swapped)
                    break;
            }
        }
    }
}