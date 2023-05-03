namespace Application.SignalR;

public class NewMessageEventArgs : EventArgs
{
    public string RecipientId { get; set; }
}