namespace AddressResolve.CityStore;

public interface ITokenCreator<TToken> where TToken : struct
{
    TToken CreateNew();
}