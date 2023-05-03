namespace Application.SignalR;

public class MessageObservable
{
    private readonly List<IMessageObserver> _observers = new List<IMessageObserver>();

    public void Attach(IMessageObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IMessageObserver observer)
    {
        _observers.Remove(observer);
    }

    public async Task NotifyNewMessageAsync(string recipientId)
    {
        var args = new NewMessageEventArgs { RecipientId = recipientId };
        foreach (var observer in _observers)
        {
            await observer.NotifyNewMessage(args);
        }
    }
}
