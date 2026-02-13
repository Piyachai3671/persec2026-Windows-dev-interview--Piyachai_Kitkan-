using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        string[] data1 = { "TH19", "SG20", "TH2" };
        string[] result1 = SortData(data1);
        Console.WriteLine(string.Join(", ", result1));

        string[] data2 = { "TH10", "TH3Netflix", "TH1", "TH7" };
        string[] result2 = SortData(data2);
        Console.WriteLine(string.Join(", ", result2));
        Console.ReadKey();
    }

    public static string[] SortData(string[] input)
    {
        return input
            .OrderBy(x => GetPrefix(x))
            .ThenBy(x => GetNumber(x))
            .ToArray();
    }

    private static string GetPrefix(string value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;

        int index = value.IndexOfAny("0123456789".ToCharArray());

        if (index == -1)
            return value;

        return value.Substring(0, index);
    }

    private static int GetNumber(string value)
    {
        if (string.IsNullOrEmpty(value))
            return 0;

        Match match = Regex.Match(value, @"\d+");

        if (!match.Success)
            return 0;

        return int.Parse(match.Value);
    }
}
