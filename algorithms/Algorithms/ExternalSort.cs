namespace Algorithms;
using System.IO;
public static class ExternalSort
{
    public static void MergeSort(string path1,string path2,string path3)
    {
        static IEnumerable<int> Merge(IEnumerable<int>arr,IEnumerable<int>arr2)
        {
            return arr.Concat(arr2).OrderBy(x => x);
        }

        var lenght = 0;
        using (var reader = new StreamReader(path1))
            while (reader.ReadLine() != null)
                lenght++;
        var size = 1;
        while (size <= lenght/2)
        {
            using (var reader = new StreamReader(path1))
            {
                using (var reader2 = new StreamWriter(path2,false))
                {
                    using (var reader3 = new StreamWriter(path3,false))
                    {
                        for (int i = 0; i < lenght; i+=size)
                        {
                            for (int j = 0; j < size; j++)
                            {
                                reader2.WriteLine(reader.ReadLine());
                            }
                            for (int j = 0; j < size; j++)
                            {
                                reader3.WriteLine(reader.ReadLine());
                            }
                        }
                    }
                }
            }
            using (var reader = new StreamWriter(path1,false))
            {
                using (var reader2 = new StreamReader(path2))
                {
                    using (var reader3 = new StreamReader(path3))
                    {
                        for (int i = 0; i < lenght; i++)
                        {
                            var listB = new List<int>();
                            var listC = new List<int>();
                            for (int j = 0; j < size; j++)
                            {
                                if(int.TryParse(reader2.ReadLine(),out var value))
                                    listB.Add(value);
                            }
                            for (int j = 0; j < size; j++)
                            {
                                if(int.TryParse(reader3.ReadLine(),out var value))
                                    listC.Add(value);
                            }

                            var res = Merge(listB, listC);
                            foreach (var item in res)
                            {
                                reader.WriteLine(item.ToString());
                            }
                        }
                    }
                }
            }
            size*=2;
        }
    }
}