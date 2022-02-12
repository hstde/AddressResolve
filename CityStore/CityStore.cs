namespace AddressResolve.CityStore;

public class CityStore<TCityToken, TCity> where TCityToken : struct
{
    private readonly Dictionary<TCityToken, TCity> store;
    private readonly ITokenCreator<TCityToken> tokenCreator;

    public CityStore(ITokenCreator<TCityToken> tokenCreator)
    {
        this.tokenCreator = tokenCreator;
        store = new Dictionary<TCityToken, TCity>();
    }

    public TCityToken Add(ICityBuilder<TCity> builder)
    {
        var city = builder.Build();
        var token = tokenCreator.CreateNew();
        store.Add(token, city);
        return token;
    }

    public TCity Get(TCityToken token)
    {
        if (!TryGet(token, out var city) || city is null)
            throw new KeyNotFoundException();

        return city;
    }

    public bool TryGet(TCityToken token, out TCity? city)
    {
        return store.TryGetValue(token, out city);
    }
}