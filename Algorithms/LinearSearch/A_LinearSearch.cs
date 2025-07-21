namespace Algorithms
{
    public class A_LinearSearch
    {
        public int LinearSearch(int[] array, int target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target) return i;
            }
            return -1;
        }
    }
}