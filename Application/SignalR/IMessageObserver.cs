namespace Application.SignalR;

public interface IMessageObserver
{
    Task NotifyNewMessage(NewMessageEventArgs args);
}