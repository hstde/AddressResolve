namespace AddressResolve.CityStore;

public class DefaultCityBuilder : ICityBuilder<City>
{
    private string? name;
    private string? asciiName;
    private uint population;

    public DefaultCityBuilder()
    {
        Clear();
    }

    public DefaultCityBuilder Clear()
    {
        name = null;
        asciiName = null;
        population = 0;
        return this;
    }

    public DefaultCityBuilder SetName(string name)
    {
        this.name = string.Intern(name);
        return this;
    }

    public DefaultCityBuilder SetAsciiName(string asciiName)
    {
        this.asciiName = string.Intern(asciiName);
        return this;
    }

    public DefaultCityBuilder SetPopulationCount(uint popCount)
    {
        population = popCount;
        return this;
    }

    public City Build()
    {
        if (asciiName is null)
            return BuildWithName();

        if (name is null)
            return BuildWithAsciiName();

        return new City(name, asciiName, population);
    }

    private City BuildWithAsciiName()
    {
        if (asciiName is null)
            throw new InvalidOperationException(
                $"Either {nameof(name)} or " +
                $"{nameof(asciiName)} or both must be set.");

        return new City(asciiName, asciiName, population);
    }

    private City BuildWithName()
    {
        if (name is null)
            throw new InvalidOperationException(
                $"Either {nameof(name)} or " +
                $"{nameof(asciiName)} or both must be set.");

        return new City(name, name, population);
    }
}
