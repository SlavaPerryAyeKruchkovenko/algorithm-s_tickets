using System.Collections;
using Microsoft.VisualBasic;

namespace Algorithms;

public static class SortAlgorithms
{
    //самый маленький элемент в начале
    public static int[] BubbleSort(int[] arr)
    {
        for (var i = 0; i < arr.Length; i++)
        {
            for (var j = i+1; j < arr.Length; j++)
            {
                if (arr[i] > arr[j])
                {
                    (arr[j], arr[i]) = (arr[i], arr[j]);
                }
            }
            foreach (var val in arr)
            {
                Console.Write(val+" ");
            }
            Console.WriteLine();
        }

        return arr;
    }
    //двигаю в лево arr[i] максильмано возможно
    public static int[] InsertSort(int[] arr)
    {
        for (var i = 1; i < arr.Length; i++)
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
    // ищу наименьшей элемент относительно arr[i] и меняю их местами
    public static int[] SelectionSort(int[] arr)
    {
        for (var i = 0; i < arr.Length-1; i++)
        {
            var index = i;
            for (var j = i+1; j < arr.Length; j++)
            {
                if (arr[j] < arr[index])
                {
                    index = j;
                }
            }
            (arr[index], arr[i]) = (arr[i], arr[index]);
            foreach (var val in arr)
            {
                Console.Write(val+" ");
            }
            Console.WriteLine();
        } 
        return arr;
    }

    public static int[] ShakerSort(int[] arr)
    {
        for (var i = 0; i < arr.Length; i++)
        {
            var needSort = false;
            for (var j = i; j < arr.Length-1-i; j++)
            {
                if (arr[j + 1] < arr[j])
                {
                    (arr[j], arr[j+1]) = (arr[j+1], arr[j]);
                    needSort = true;
                }
            }
            foreach (var val in arr)
            {
                Console.Write(val+" ");
            }
            Console.WriteLine();
            for (var j = arr.Length-2-i; j > i; j--)
            {
                if (arr[j] < arr[j - 1])
                {
                    (arr[j], arr[j-1]) = (arr[j-1], arr[j]);
                    needSort = true;
                }
            }
            foreach (var val in arr)
            {
                Console.Write(val+" ");
            }
            Console.WriteLine();
            if (!needSort)
            {
                return arr;
            }
        }
        return arr;
    }

    public static int[] ShellSort(int[] array)
    {
        for (var step = (array.Length - 1) / 2; step > 0; step /= 2)
        {
            for (var i = 0; i < step; i++)
            {
                for (var j = i; j + step < array.Length; j += step)
                {
                    if (array[j] > array[j + step]) (array[j], array[j + step]) = (array[j + step], array[j]);
                }
            }
        }

        return array;
    }

    public static int[] QuickSort(int[] arr,int first,int last)
    {
        static int Sort(int[] arr,int first,int last)
        {
            var market = first;
            var pivot = arr[last];//pivot выбирается различными способами в данной реализации я вязл его как последний элемент
            for (var i = first; i < last; i++)
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
        
        var pivot = Sort(arr, first, last);
        QuickSort (arr, first, pivot-1);
        QuickSort (arr, pivot+1, last);
        return arr;
    }

    public static int[] RadixSort(int[] arr)
    {
        static int [] GetArr(Dictionary<int,List<int>> table)
        {
            var list = new List<int>();
            for (var i = -9; i <= 9; i++)
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
            var lenght = (int)Math.Log10(item) + 1;
            if (lenght > maxlenght)
            {
                maxlenght = lenght;
            }
        }
        var table = new Dictionary<int, List<int>>();
        for (var i = -9; i <=9; i++)
        {
            table.Add(i,new List<int>());
        }

        var mul = 1;
        for (var k = 0; k < maxlenght; k++)
        {
            for (var i = 0; i < arr.Length; i++)
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