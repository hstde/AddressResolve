namespace AddressResolve.FileReader;

public class CsvReader
{
    public CsvFile Read(string path)
    {
        return new CsvFileBuilder().Build();
    }
}