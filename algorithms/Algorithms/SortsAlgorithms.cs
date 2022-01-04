using System.Collections;
using Microsoft.VisualBasic;

namespace Algorithms;

public static class SortAlgorithms
{
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