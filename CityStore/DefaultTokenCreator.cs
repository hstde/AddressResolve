namespace AddressResolve.CityStore;

public class DefaultTokenCreator : ITokenCreator<ulong>
{
    private ulong currentToken;

    public DefaultTokenCreator()
    {
        currentToken = 0;
    }

    public ulong CreateNew()
    {
        return currentToken++;
    }
}
