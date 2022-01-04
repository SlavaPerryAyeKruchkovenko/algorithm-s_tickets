namespace Algorithms;

public static class SortAlgorithms
{

    public static int[] ShakerSort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            var needSort = false;
            for (int j = i; j < arr.Length-1-i; j++)
            {
                if (arr[j + 1] < arr[j])
                {
                    (arr[j], arr[j+1]) = (arr[j+1], arr[j]);
                    needSort = true;
                }
            }
            for (int j = arr.Length-2-i; j > i; j--)
            {
                if (arr[j] < arr[j - 1])
                {
                    (arr[j], arr[j-1]) = (arr[j-1], arr[j]);
                    needSort = true;
                }
            }

            if (!needSort)
            {
                return arr;
            }
        }
        return arr;
    }
}