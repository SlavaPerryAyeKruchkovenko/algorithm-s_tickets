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
}