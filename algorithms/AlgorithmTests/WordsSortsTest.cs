using System.Linq;

namespace AlgorithmTests;
using Xunit;
using System.Collections.Generic;
using Algorithms;
public class WordsSortsTest
{
    [Theory]
    [MemberData(nameof(GetArrays))]
    public void RadixSortTest(string[] arr)
    {
        arr = WordsSorts.ABSSort(arr);
        var res = arr.OrderBy(x => x);
        Assert.Equal(arr,res);
    }
    public static IEnumerable<object[]> GetArrays()
    {
        yield return new object[] { new[]{"putin5", "putin2", "putin3", "putin4","slava"} };
        yield return new object[] { new []{"a","c","e","b","d"} };
    }
}