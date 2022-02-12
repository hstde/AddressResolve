namespace AddressResolve.CityStore;

public class City
{
    public string CityName { get; }
    public string CityNameAscii { get; }
    public uint PopulationCount { get; }

    public City(string name, string nameAscii, uint popCount)
    {
        CityName = name;
        CityNameAscii = nameAscii;
        PopulationCount = popCount;
    }

    public override string ToString()
    {
        return $"{CityName}({CityNameAscii}) Pop.: {PopulationCount}";
    }
}