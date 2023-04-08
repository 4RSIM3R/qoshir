namespace Qoshir.Grain
{
    public interface IUrlShortenerGrain : IGrainWithStringKey
    {

        Task SetUrl(string shortenedRouteSegment, string fullUrl);
        Task<String> GetUrl();

    }
}
