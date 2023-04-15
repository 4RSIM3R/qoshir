using Orleans.Runtime;

namespace Qoshir.Grain
{
    public class UrlShortenerGrain : IGrain, IUrlShortenerGrain
    {

        private IPersistentState<KeyValuePair<string, string>> _cache;

        public UrlShortenerGrain([PersistentState(
            stateName: "url",
            storageName: "urls")]
            IPersistentState<KeyValuePair<string, string>> state) => _cache = state;

        public Task<string> GetUrl()
        {
            return Task.FromResult(_cache.State.Value);
        }

        public Task SetUrl(string shortenedRouteSegment, string fullUrl)
        {
            // _cache = new KeyValuePair<string, string>(shortenedRouteSegment, fullUrl);
            // return Task.CompletedTask;
            _cache.State = new KeyValuePair<string, string>(shortenedRouteSegment, fullUrl);
            return _cache.WriteStateAsync();
        }
    }
}
