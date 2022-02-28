using AddressResolve.IO;

namespace AddressResolve;

public static class Program
{
    public static int Main(string[] args)
    {
        var csv = new CsvFile.Builder()
            .AddHeader(new[] {"a", "b", "c", "d e"})
            .AddRow(new[] { "1", "2", "3", "7"})
            .AddRow(new[] { "4", "5", "6", " 8 "})
            .Build();

        var writer = new CsvWriter(Console.Out);
        writer.Write(csv);

        return 1;
    }
}