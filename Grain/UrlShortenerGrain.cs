namespace Qoshir.Grain
{
    public class UrlShortenerGrain : IGrain, IUrlShortenerGrain
    {

        private KeyValuePair<String, String> _cache;

        public Task<string> GetUrl()
        {
            return Task.FromResult(_cache.Value);
        }

        public Task SetUrl(string shortenedRouteSegment, string fullUrl)
        {
            _cache = new KeyValuePair<string, string>(shortenedRouteSegment, fullUrl);
            return Task.CompletedTask;
        }
    }
}
