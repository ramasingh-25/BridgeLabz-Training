using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using FundooNotes.Service.Interface;

namespace FundooNotes.Service.Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly ILogger<RedisCacheService>? _logger;
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public RedisCacheService(IDistributedCache distributedCache, ILogger<RedisCacheService>? logger = null)
        {
            _distributedCache = distributedCache;
            _logger = logger;
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            try
            {
                var cachedData = await _distributedCache.GetStringAsync(key);
                if (string.IsNullOrEmpty(cachedData))
                {
                    return default;
                }

                return JsonSerializer.Deserialize<T>(cachedData, _jsonOptions);
            }
            catch (Exception ex)
            {
                _logger?.LogWarning(ex, "Error retrieving key '{Key}' from Redis cache.", key);
                return default;
            }
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? absoluteExpireTime = null)
        {
            try
            {
                var options = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromMinutes(10)
                };

                var jsonData = JsonSerializer.Serialize(value, _jsonOptions);
                await _distributedCache.SetStringAsync(key, jsonData, options);
            }
            catch (Exception ex)
            {
                _logger?.LogWarning(ex, "Error setting key '{Key}' in Redis cache.", key);
            }
        }

        public async Task RemoveAsync(string key)
        {
            try
            {
                await _distributedCache.RemoveAsync(key);
            }
            catch (Exception ex)
            {
                _logger?.LogWarning(ex, "Error removing key '{Key}' from Redis cache.", key);
            }
        }
    }
}
