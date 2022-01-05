using System;
using System.Reflection.PortableExecutable;
using System.Text;

namespace AlgorithmTests;
using Xunit;
using Algorithms;
using System.Collections.Generic;

public class HashTableTests
{
    [Fact]
    public void HashTableTest()
    {
        var table = new HashTable<int, string>(1000);
        //table = RandomTable(table);
        Assert.True(table.PercentageOfFilling()>=99.0);
        Assert.True(table.CountOfFewerList() >= 95);
        Assert.True(table.CountOfLongestList() <= 105);
    }
    [Fact]
    public void GoodHashTableTest()
    {
        uint size = 100;
        var table = new GoodHashTable<int, string>(size);
        var count = (int) (size * 0.9);
        table = RandomTable(table,count);
        Assert.True(table.GetCountOfCollision()< count*0.1);
        Assert.True(table.PercentageOfFilling() >= count*0.9);
    }
    public static GoodHashTable<int,string> RandomTable(GoodHashTable<int, string> table,int count)
    {
        for (int i = 0; i < count; i++)
        {
            table.Add(i, RandomString(2, 8));
        }
        return table;
    }
    private static string RandomString(int minSize,int maxSize)
    {
        if(0 < maxSize - minSize && maxSize>0 && minSize > 0)
        {
            var str = new StringBuilder();
            var size = new Random().Next(minSize, maxSize);
            for (int i = 0; i < size; i++)
            {
                str.Append(new Random().Next('a', 'z').ToString());
            }
            return str.ToString();
        }
        throw new Exception("Incorrect value");
    }
}