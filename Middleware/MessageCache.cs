using Microsoft.Extensions.Caching.Memory;

public class MessageCache
{
    private readonly IMemoryCache _cache;

    public MessageCache(IMemoryCache cache)
    {
        _cache = cache;
    }

    public void CacheMessage(string key, string message)
    {
        _cache.Set(key, message, TimeSpan.FromMinutes(5)); // Cache for 5 minutes
    }

    public string GetCachedMessage(string key)
    {
        _cache.TryGetValue(key, out string message);
        return message;
    }
}