using OnlineUserManagment.Domain.Contracts;
using StackExchange.Redis;

namespace OnlineUserManagment.Infrastructure.Services
{
    public class UserTrackingService: IUserTrackingService
    {
        private readonly IConnectionMultiplexer _redis;
        private const string OnlineUsersKey = "online_users";

        public UserTrackingService(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public async Task UserOnlineAsync(string userInfo)
        {
            var db = _redis.GetDatabase();
            await db.HashSetAsync(OnlineUsersKey, userInfo, DateTime.UtcNow.ToString());
            await db.KeyExpireAsync(OnlineUsersKey, TimeSpan.FromMinutes(1));
        }

        public async Task UserOfflineAsync(string userInfo)
        {
            var db = _redis.GetDatabase();
            await db.HashDeleteAsync(OnlineUsersKey, userInfo);
        }

        public async Task<int> GetOnlineUserCountAsync()
        {
            var db = _redis.GetDatabase();
            var onlineUsers = await db.HashLengthAsync(OnlineUsersKey);
            return (int)onlineUsers;
        }
    }
}
