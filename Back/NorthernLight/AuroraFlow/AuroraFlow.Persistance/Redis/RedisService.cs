using StackExchange.Redis;

namespace AuroraFlow.Persistance.Redis;

public class RedisService(IConnectionMultiplexer redis) : IRedisService
{
    // Helper method to check if at least one endpoint is connected.
    public bool IsConnected()
    {
        var endpoints = redis.GetEndPoints();
        return endpoints.Select(endpoint => redis.GetServer(endpoint)).Any(server => server.IsConnected);
    }

    public async Task SetValueAsync(string key, string value)
    {
        if (!IsConnected())
        {
            // Fallback logic: For example, log the issue or use an alternative storage
            // Here we just return early.
            return;
        }

        var db = redis.GetDatabase();
        await db.StringSetAsync(key, value);
    }

    public async Task<string?> GetValueAsync(string key)
    {
        if (!IsConnected())
        {
            // Fallback logic: For example, log the issue or return a default value
            return null;
        }

        var db = redis.GetDatabase();
        return await db.StringGetAsync(key);
    }
}