namespace LogicUnitTests;

public class LogicUnitTest
{
    [Fact]
    public async Task Message_is_stored_and_sent_when_it_is_updated()
    {
        var persistence = Substitute.For<IPersistence>();
        var emailSender = Substitute.For<IEmailSender>();
        var logic = new Logic.Logic(persistence, emailSender);
        var message = "test message";

        await logic.UpdateMessage(message);

        await persistence.Received().SetMessage(message);
        await emailSender.Received().SendMessage(message);
    }
    
    [Fact]
    public async Task Message_is_cleared_when_requested()
    {
        var persistence = Substitute.For<IPersistence>();
        var emailSender = Substitute.For<IEmailSender>();
        var logic = new Logic.Logic(persistence, emailSender);

        await logic.ClearMessage();

        await persistence.Received().ClearMessage();
    }
}