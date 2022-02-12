using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace AddressResolve.FileReader;

public class CsvFile
{
    public struct CsvLine
    {
        public string this[string column] => file.store[column][lineNumber];
        private int lineNumber;
        private CsvFile file;

        internal CsvLine(CsvFile file, int lineNumber)
        {
            this.file = file;
            this.lineNumber = lineNumber;
        }
    }

    public IReadOnlyCollection<string> Header => store.Keys;
    public int LineCount => store.First().Value.Length;

    public CsvLine this[int lineNumber] => new CsvLine(this, lineNumber);

    private readonly Dictionary<string, string[]> store;

    internal CsvFile(Dictionary<string, string[]> store)
    {
        this.store = store;
    }
}
