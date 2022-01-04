
using System.Collections.Generic;

using Xunit;
using Algorithms;
using System.Linq;

namespace AlgorithmTests;

public class SortAlgTests
{
    [Theory]
    [MemberData(nameof(GetArrs))]
    public void BubuleTest(int[] arr)
    {
        arr = SortAlgorithms.BublleSort(arr);
        var res = arr.OrderBy(x=>x).ToArray();
        Assert.Equal(arr,res);
    }
    public static IEnumerable<object[]> GetArrs()
    {
        yield return new object[] { new []{9, 7, 6, 2, 1} };
        yield return new object[] { new []{1,2,3,4,9} };
        yield return new object[] { new []{80,290,0,12,-10} };
        yield return new object[] { new []{-10,-90,-88,-92,-102,-180} };
    }
}