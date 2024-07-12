namespace Specs.Drivers;

public sealed class EmailSenderDriver
{
    public IEmailSender EmailSender { get; } = Substitute.For<IEmailSender>();

    public async Task CheckMessageReceived(string message)
    {
        await EmailSender.Received().SendMessage(message);
    }
}
