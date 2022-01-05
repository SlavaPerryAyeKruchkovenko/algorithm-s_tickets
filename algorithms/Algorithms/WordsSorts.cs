namespace Algorithms;

public static class WordsSorts
{
    public static string[] ABSSort(string[] arr)
    {
        static string[] GetArr(Dictionary<char,List<string>> table)
        {
            var list = new List<string>();
            foreach (var items in table.OrderBy(x=>x.Key))
            {
                foreach (var item in items.Value)
                {
                    list.Add(item);
                }
            }
            table.Clear();
            return list.ToArray();
        }
        var maxlength = 1;
        foreach (var item in arr)
        {
            if (item.Length > maxlength)
            {
                maxlength = item.Length;
            }
        }
        var table = new Dictionary<char, List<string>>();
        var mul = 1;
        for (var rank = maxlength-1; rank >= 0; rank--)
        {
            foreach (var item in arr)
            {
                var key = rank<item.Length?item[rank]:' ';
                if (table.ContainsKey(key))
                {
                    table[key].Add(item);
                }
                else
                {
                    var list = new List<string>();
                    list.Add(item);
                    table.Add(key,list);
                }
            }

            arr = GetArr(table);
        }
        return arr;
    }
}