namespace Algorithms;

public static class SortAlgorithms
{
    public static int[] ShellSort(int[] arr)
    {
        var steep = arr.Length / 2;
        while (steep >= 1)
        {
            steep = steep / 2;
            for (var i = steep; i < arr.Length; i++)
            {
                var j = i;
                while ((j >= steep) && (arr[j - steep] > arr[j]))
                {
                    (arr[j], arr[j-steep]) = (arr[j-steep], arr[j]);
                    j = j - steep;
                }
            }
        }
        return arr;
    }
}