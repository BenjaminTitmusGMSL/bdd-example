namespace Logic.Interfaces;

public interface IEmailSender
{
    public Task SendMessage(string message);
}