namespace OnlineUserManagment.Domain.Contracts
{
    public interface IUserTrackingService
    {
        Task UserOnlineAsync(string userInfo);
        Task UserOfflineAsync(string userInfo);
        Task<int> GetOnlineUserCountAsync();
    }
}
