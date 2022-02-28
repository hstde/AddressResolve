using System.Text;

namespace AddressResolve.IO;

public class CsvWriter
{
    const char DEFAULT_SEPARATOR = ';';

    private readonly TextWriter writer;

    public CsvWriter(TextWriter writer)
    {
        this.writer = writer;
    }

    public void Write(CsvFile file)
    {
        var header = string.Join(DEFAULT_SEPARATOR, file.Header.Select(ToEscapedString));
        writer.WriteLineAsync(header);
        foreach (var line in file)
        {
            writer.WriteLineAsync(string.Join(DEFAULT_SEPARATOR, line.Select(ToEscapedString)));
        }
        writer.FlushAsync();
    }

    private string ToEscapedString(string item)
    {
        if (item.Contains(" "))
            return '"' + item + '"';
        return item;
    }

    public void Write(string path, CsvFile file)
    {
        using var fileWriter = new StreamWriter(path);
        var writer = new CsvWriter(fileWriter);
        writer.Write(file);
    }
}