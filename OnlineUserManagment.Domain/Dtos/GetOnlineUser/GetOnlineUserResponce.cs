namespace OnlineUserManagment.Domain.Dtos.GetOnlineUser
{
    public class GetOnlineUserResponce
    {
        public int Status { get; set; }
        public string Massage { get; set; }
        public int AllUserCount { get; set; }
        public int TodayUserCount { get; set; }
        public int OnlineUserCount { get; set; }
    }
}
