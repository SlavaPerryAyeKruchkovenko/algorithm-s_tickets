namespace Algorithms;

public static class SortAlgorithms
{
    

    public static int[] SelectionSort(int[] arr)
    {
        for (int i = 0; i < arr.Length-1; i++)
        {
            var index = i;
            for (int j = i+1; j < arr.Length; j++)
            {
                if (arr[j] < arr[index])
                {
                    index = j;
                }
            }
            (arr[index], arr[i]) = (arr[i], arr[index]);
        } 
        return arr;
    }
}