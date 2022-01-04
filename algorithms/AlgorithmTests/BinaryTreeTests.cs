using System;
using Xunit;
using Algorithms;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmTests;

public class BinaryTreeTests
{
    [Theory]
    [MemberData(nameof(GetArrays))]
    public void BinarySortTest(int[] arr,int key)
    {
        var res  = BinaryTree.BinarySort(arr);
        arr = arr.OrderBy(x => x).ToArray();
        Assert.Equal(arr,res);
    }
    public static IEnumerable<object[]> GetArrays()
    {
        yield return new object[] { new[]{9, 7, 6, 2, 1},9 };
        yield return new object[] { new []{1,2,3,4,9},3 };
        yield return new object[] { new []{80,290,0,12,-10},12 };
        yield return new object[] { new []{-10,-90,-88,-92,-102,-180},-88 };
    }
}