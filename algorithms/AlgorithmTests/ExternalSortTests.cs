using System;
using Xunit;
using Algorithms;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgorithmTests;

public class ExternalSortTests
{
    [Fact]
    public void MergeTest()
    {
        var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        var path1 = Path.Combine(desktopPath, "A.txt");
        var path2 = Path.Combine(desktopPath, "B.txt");
        var path3 = Path.Combine(desktopPath, "C.txt");
        var list = new List<int>();
        foreach (var item in File.ReadLines(path1))
        {
            if (int.TryParse(item, out var value))
            {
                list.Add(value);
            }
        }
        ExternalSort.MergeSort(path1,path2,path3);
        var list2 = new List<int>();
        foreach (var item in File.ReadLines(path1))
        {
            if (int.TryParse(item, out var value))
            {
                list2.Add(value);
            }
        }
        Assert.Equal(list.OrderBy(x=>x),list2.OrderBy(x=>x));
    }
}