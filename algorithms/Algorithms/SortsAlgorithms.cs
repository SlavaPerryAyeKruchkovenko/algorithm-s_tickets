using Microsoft.VisualBasic;

namespace Algorithms;

public static class SortAlgorithms
{
    public static int[] QuickSort(int[] arr,int first,int last)
    {
        static int Sort(int[] arr,int first,int last)
        {
            var market = first;
            var pivot = arr[last];//pivot выбирается различными способами в данной реализации я вязл его как последний элемент
            for (int i = first; i < last; i++)
            {
                if (arr[i] < pivot)
                {
                    (arr[market], arr[i]) = (arr[i], arr[market]);
                    market++;
                }
            }
            (arr[market], arr[last]) = (arr[last], arr[market]);
            return market;
        }
        if ( first >= last)
            return arr;
        
        int pivot = Sort(arr, first, last);
        QuickSort (arr, first, pivot-1);
        QuickSort (arr, pivot+1, last);
        return arr;
    }
}