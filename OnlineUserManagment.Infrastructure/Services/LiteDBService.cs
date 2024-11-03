using LiteDB;
using OnlineUserManagment.Domain.Contracts;
using OnlineUserManagment.Domain.Dtos.LiteDbUserInfo;

namespace OnlineUserManagment.Infrastructure.Services
{
    public class LiteDBService : ILiteDBService
    {
        private readonly string _databasePath = "MyData.db";

        public LiteDBService()
        {
        }

        public void DeleteProduct(int id)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var collection = db.GetCollection<UserInfo>("user");
                collection.Delete(id);
            }
        }

        public int GetAllUserInfos()
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var collection = db.GetCollection<UserInfo>("user");
                return collection.FindAll().ToList().Count();
            }
        }

        public int GetTodayProducts()
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var collection = db.GetCollection<UserInfo>("user");

                // Get today's date without the time component
                var today = DateTime.UtcNow.Date;

                // Query for products created today
                return collection
                    .Find(x => x.CreatedAt >= today && x.CreatedAt < today.AddDays(1))
                    .ToList().Count();
            }
        }

        public UserInfo GetUserInfoById(int id)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var collection = db.GetCollection<UserInfo>("user");
                return collection.FindById(id);
            }
        }

        public void InsertUserInfo(UserInfo userInfo)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var collection = db.GetCollection<UserInfo>("user");
                userInfo.CreatedAt = DateTime.Now;
                collection.Insert(userInfo);
            }
        }
    }
}
