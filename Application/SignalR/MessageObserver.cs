using Microsoft.AspNetCore.SignalR;

namespace Application.SignalR;

public class MessageObserver : IMessageObserver
{
    private readonly IHubContext<MessageHub> hubContext;

    public MessageObserver(IHubContext<MessageHub> hubContext)
    {
        this.hubContext = hubContext;
    }

    public async Task NotifyNewMessage(NewMessageEventArgs args)
    {
        await hubContext.Clients.User(args.RecipientId).SendAsync("NewMessageNotification");
    }
}