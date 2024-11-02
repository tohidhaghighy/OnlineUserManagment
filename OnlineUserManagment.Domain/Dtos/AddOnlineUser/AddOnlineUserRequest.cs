namespace OnlineUserManagment.Domain.Dtos.AddOnlineUser
{
    public class AddOnlineUserRequest
    {
        public string Ip { get; set; }
        public string Date { get; set; }
        public string Browser { get; set; }
        public string UniqueClientId { get; set; }
    }
}
