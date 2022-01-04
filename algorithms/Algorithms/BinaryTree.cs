namespace Algorithms;

public static class BinaryTree
{
    public static int BinarySearch(int key,int[] arr,int min,int max)
    {
        if (max < min) return -1;
        var middle = (min + max) / 2;
        var value = arr[middle];
        if (value == key)
            return middle;
        else
            return value > key ? BinarySearch(key, arr, min, middle - 1) : BinarySearch(key, arr, middle + 1, max);
    }
}