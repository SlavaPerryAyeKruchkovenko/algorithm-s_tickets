using System.Collections;
using Microsoft.VisualBasic;

namespace Algorithms;

public static class SortAlgorithms
{
    public static int[] BubbleSort(int[] arr)
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

    public static int[] RadixSort(int[] arr)
    {
        static int [] GetArr(Dictionary<int,List<int>> table)
        {
            var list = new List<int>();
            for (int i = -9; i <= 9; i++)
            {
                foreach (var item in table[i])
                {
                    list.Add(item);
                }

                table[i] = new List<int>();
            }

            return list.ToArray();
        }
        var maxlenght = 1;
        foreach (var item in arr)
        {
            var word = item.ToString();
            if (word.Length > maxlenght)
            {
                maxlenght = word.Length;
            }
        }
        var table = new Dictionary<int, List<int>>();
        for (int i = -9; i <=9; i++)
        {
            table.Add(i,new List<int>());
        }

        var mul = 1;
        for (int k = 0; k < maxlenght; k++)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                var key = (arr[i] / mul) % 10;
                table[key].Add(arr[i]);
            }

            mul *= 10;
            arr = GetArr(table);
        }
        return arr;
    }
}