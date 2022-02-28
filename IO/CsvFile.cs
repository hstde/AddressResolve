namespace AddressResolve.IO;

public partial class CsvFile : IEnumerable<CsvFile.CsvLine>
{
    public IEnumerable<string> Header => store.Keys;
    public int LineCount { get; }

    public CsvFile.CsvLine this[int lineNumber] => new CsvFile.CsvLine(this, lineNumber);

    private readonly IReadOnlyDictionary<string, string[]> store;

    private CsvFile(IReadOnlyDictionary<string, string[]> store)
    {
        this.store = store;
        this.LineCount = store.First().Value.Length;
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => this.GetEnumerator();

    public IEnumerator<CsvFile.CsvLine> GetEnumerator()
    {
        for (int i = 0; i < LineCount; i++)
        {
            yield return this[i];
        }
    }
}
