using System.Collections.Generic;

public static class ListExtention
{
    public static List<T> Trim<T>(this List<T> items, int begin, int end)
    {
        var result = new List<T>();
        for (int i = begin; i < end; i++)
        {
            result.Add(items[i]);
        }
        items.RemoveRange(begin, end - begin);
        return result;
    }
}