namespace AddressResolve.IO;

public partial class CsvFile
{
    public class Builder
    {
        private string[] headers;
        private List<string>[] rows;

        public Builder()
        {
            headers = Array.Empty<string>();
            rows = Array.Empty<List<string>>();
        }

        public Builder AddHeader(IReadOnlyList<string> headers)
        {
            ThrowOnHeaderOverwrite();

            this.headers = headers.ToArray();
            rows = new List<string>[headers.Count];

            for(int i = 0; i < rows.Length; i++)
            {
                rows[i] = new List<string>();
            }

            return this;
        }

        private void ThrowOnHeaderOverwrite()
        {
            if (headers.Length != 0)
            {
                throw new InvalidOperationException("Header fields already defined!");
            }
        }

        public Builder AddRow(IReadOnlyList<string> row)
        {
            ThrowOnInvalidColumnCount(row.Count);

            for (int i = 0; i < rows.Length; i++)
            {
                rows[i].Add(row[i]);
            }

            return this;
        }

        private void ThrowOnInvalidColumnCount(int actualCount)
        {
            int expectedCount = headers.Length;
            if (expectedCount == 0)
            {
                throw new InvalidOperationException($"No header fields defined!");
            }

            if (actualCount != expectedCount)
            {
                throw new InvalidOperationException($"Expected {expectedCount} but got {actualCount} items in row.");
            }
        }

        public CsvFile Build()
        {
            return new CsvFile(GetFileStore());
        }

        private IReadOnlyDictionary<string, string[]> GetFileStore()
        {
            var fileStore = new Dictionary<string, string[]>(headers.Length);
            
            for (int i = 0; i < headers.Length; i++)
            {
                fileStore[headers[i]] = rows[i].ToArray();
            }

            return fileStore;
        }
    }
}
