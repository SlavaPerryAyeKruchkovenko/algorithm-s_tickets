
using System.Collections.Generic;
using Xunit;
using Algorithms;
using System.Linq;

namespace AlgorithmTests;

public class SortAlgTests
{
    [Theory]
    [MemberData(nameof(GetArrays))]
    public void ShellTest(int[] arr)
    {
        arr = SortAlgorithms.ShellSort(arr);
        var res = arr.OrderBy(x=>x).ToArray();
        Assert.Equal(arr,res);
    }
    
    public static IEnumerable<object[]> GetArrays()
    {
        yield return new object[] { new[]{9, 7, 6, 2, 1} };
        yield return new object[] { new []{1,2,3,4,9} };
        yield return new object[] { new []{80,290,0,12,-10} };
        yield return new object[] { new []{-10,-90,-88,-92,-102,-180} };
    }
}