namespace Algorithms;

public static class SortAlgorithms
{
    public static int[] BublleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i+1; j < arr.Length; j++)
            {
                if (arr[i] > arr[j])
                {
                    (arr[j], arr[i]) = (arr[i], arr[j]);
                }
            }
        }

        return arr;
    }
}