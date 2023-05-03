using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.SignalR;

public class MessageHub : Hub
{
    private readonly MessageObservable observable;

    public MessageHub(MessageObservable observable)
    {
        this.observable = observable;
    }

    public async Task SendMessage(string recipientId, string message)
    {
        // Отправка сообщения пользователю с указанным идентификатором
        await Clients.User(recipientId).SendAsync("ReceiveMessage", message);
    }

    public override async Task OnConnectedAsync()
    {
        // Регистрация наблюдателя при подключении нового клиента
        var observer = new MessageObserver(Context.GetHttpContext().RequestServices.GetRequiredService<IHubContext<MessageHub>>());
        observable.Attach(observer);

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        // Отмена регистрации наблюдателя при отключении клиента
        var observer = new MessageObserver(Context.GetHttpContext().RequestServices.GetRequiredService<IHubContext<MessageHub>>());
        observable.Detach(observer);

        await base.OnDisconnectedAsync(exception);
    }
}