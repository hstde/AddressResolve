namespace AddressResolve.IO;

public partial class CsvFile
{
    public struct CsvLine : IEnumerable<string>
    {
        public string this[string column] => file.store[column][LineNumber];
        public int LineNumber { get; }
        private CsvFile file;

        public CsvLine(CsvFile file, int lineNumber)
        {
            this.file = file;
            this.LineNumber = lineNumber;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => this.GetEnumerator();

        public IEnumerator<string> GetEnumerator()
        {
            foreach (var column in file.store.Keys)
            {
                yield return this[column];
            }
        }
    }
}
