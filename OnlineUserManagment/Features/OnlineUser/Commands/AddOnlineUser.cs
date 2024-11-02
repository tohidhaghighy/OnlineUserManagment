using System.Text.Json;
using FastEndpoints;
using OnlineUserManagment.Domain.Contracts;
using OnlineUserManagment.Domain.Dtos.AddOnlineUser;

namespace OnlineUserManagment.Features.OnlineUser.Commands
{
    public class AddOnlineUser(IUserTrackingService userTrackingService) : Endpoint<AddOnlineUserRequest, AddOnlineUserResponce>
    {
        public override void Configure()
        {
            Post("/api/user/adduser");
            AllowAnonymous();
        }

        public override async Task HandleAsync(AddOnlineUserRequest req, CancellationToken ct)
        {
            try
            {
                await userTrackingService.UserOnlineAsync(JsonSerializer.Serialize(req));
                
            }
            catch (Exception ex)
            {
                await SendAsync(new()
                {
                    Id = 1,
                    Status = 400,
                    Message = ex.Message
                });
            }
            
        }
    }
}
