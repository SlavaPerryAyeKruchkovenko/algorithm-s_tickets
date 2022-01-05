using System.Linq;

namespace AlgorithmTests;
using Xunit;
using System.Collections.Generic;
using Algorithms;
public class DataTypesTests
{
    [Theory]
    [MemberData(nameof(GetArrays))]
    public void StackTest(int[] arr)
    {
        var stack = new MyStack<int>();
        foreach (var item in arr)
        {
            stack.Push(item);
        }
        var list = new List<int>();
        var count = stack.Count();
        for (int i = 0; i < count; i++)
        {
            list.Add(stack.Pop());
        }
        Assert.Equal(arr.Reverse().ToArray(), list.ToArray());
    }
    
    public static IEnumerable<object[]> GetArrays()
    {
        yield return new object[] { new[]{9, 7, 6, 2, 1} };
        yield return new object[] { new []{1,2,3,4,9} };
    }
}