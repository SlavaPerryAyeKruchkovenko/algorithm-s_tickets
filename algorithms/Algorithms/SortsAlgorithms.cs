namespace Algorithms;

public static class SortAlgorithms
{
    

    public static int[] InsertSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            var k = i - 1;
            var el = arr[i];
            while (k>=0 && arr[k]>el)
            {
                arr[k+1] = arr[k];
                k--;
            }
            arr[k+1] = el;
        }
        return arr;
    }
}