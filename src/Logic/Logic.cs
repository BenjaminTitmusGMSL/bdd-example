using Logic.Interfaces;

namespace Logic;

public class Logic(IPersistence persistence, IEmailSender emailSender) : ILogic
{
    public async Task UpdateMessage(string message)
    {
        await persistence.SetMessage(message);
        await emailSender.SendMessage(message);
    }

    public async Task ClearMessage()
    {
        await persistence.ClearMessage();
    }
}