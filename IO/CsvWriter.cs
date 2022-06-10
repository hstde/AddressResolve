using System.Text;

namespace AddressResolve.IO;

public class CsvWriter
{
    const char DEFAULT_SEPARATOR = ';';
    const char ESCAPE_CHARACTER = '"';

    private readonly TextWriter writer;
    private readonly char separator;
    private readonly Lazy<string[]> symbolsToEscape;

    public CsvWriter(TextWriter writer)
    {
        this.writer = writer;
        this.separator = DEFAULT_SEPARATOR;
        this.symbolsToEscape = new Lazy<string[]>(GetSymbolsToEscape);
    }

    public void Write(CsvFile file)
    {
        var header = string.Join(separator, file.Header.Select(ToEscapedString));
        writer.WriteLineAsync(header);
        foreach (var line in file)
        {
            writer.WriteLineAsync(string.Join(separator, line.Select(ToEscapedString)));
        }
        writer.FlushAsync();
    }

    private string ToEscapedString(string item)
    {
        if (symbolsToEscape.Value.Any(item.Contains))
            return ESCAPE_CHARACTER + item + ESCAPE_CHARACTER;
        return item;
    }

    private string[] GetSymbolsToEscape()
    {
        return new[] { " ", separator.ToString() };
    }

    public void Write(string path, CsvFile file)
    {
        using var fileWriter = new StreamWriter(path);
        var writer = new CsvWriter(fileWriter);
        writer.Write(file);
    }
}