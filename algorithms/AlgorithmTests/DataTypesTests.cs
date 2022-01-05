using System.Linq;

namespace AlgorithmTests;
using Xunit;
using System.Collections.Generic;
using Algorithms;
public class DataTypesTests
{
    [Theory]
    [MemberData(nameof(GetArrays))]
    public void QueueTest(int[] arr)
    {
        var queue = new MyQueue<int>();
        foreach (var item in arr)
        {
            queue.Enqueue(item);
        }
        var list = new List<int>();
        var count = queue.Count();
        for (int i = 0; i < count; i++)
        {
            list.Add(queue.Dequeue());
        }
        Assert.Equal(arr, list.ToArray());
    }
    public static IEnumerable<object[]> GetArrays()
    {
        yield return new object[] { new[]{9, 7, 6, 2, 1} };
        yield return new object[] { new []{1,2,3,4,9} };
    }
}