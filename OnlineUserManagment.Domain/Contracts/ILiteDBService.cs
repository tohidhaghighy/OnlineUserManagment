using OnlineUserManagment.Domain.Dtos.LiteDbUserInfo;

namespace OnlineUserManagment.Domain.Contracts
{
    public interface ILiteDBService
    {
        void InsertUserInfo(UserInfo userInfo);
        int GetAllUserInfos();
        UserInfo GetUserInfoById(int id);
        void DeleteProduct(int id);
        int GetTodayProducts();
    }
}
