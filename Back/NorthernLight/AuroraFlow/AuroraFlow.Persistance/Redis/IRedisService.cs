namespace AuroraFlow.Persistance.Redis;

public interface IRedisService
{
    public bool IsConnected();
    public Task SetValueAsync(string key, string value);
    public Task<string?> GetValueAsync(string key);
}