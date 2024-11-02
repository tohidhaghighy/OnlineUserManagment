﻿using FastEndpoints;
using OnlineUserManagment.Domain.Contracts;
using OnlineUserManagment.Domain.Dtos.GetOnlineUser;

namespace OnlineUserManagment.Features.OnlineUser.Queries
{
    public class GetOnlineUserCount(IUserTrackingService userTrackingService) : Endpoint<EmptyRequest, GetOnlineUserResponce>
    {
        public override void Configure()
        {
            Get("/api/user/getUserCount");
            AllowAnonymous();
        }

        public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
        {
            try
            {
                var onlineUserCount = await userTrackingService.GetOnlineUserCountAsync();
                await SendAsync(new()
                {
                    OnlineUserCount = onlineUserCount,
                    Status=200,
                    Massage=""
                });
            }
            catch (Exception ex)
            {
                await SendAsync(new()
                {
                    OnlineUserCount = 0,
                    Massage = "",
                    Status = 400
                });
            }
        }
    }
}